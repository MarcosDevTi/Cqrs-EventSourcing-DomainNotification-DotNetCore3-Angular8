using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Arch.Infra.Shared.Cqrs;
using Microsoft.Extensions.DependencyInjection;

namespace Arch.Handlers.Extensions
{
    public static class CqrsExtensions
    {
        public static void AddCqrs(this IServiceCollection services, params Type[] HandlerAssemblies) =>
            GetDependencies(HandlerAssemblies).ForEach(_ => 
                    services.AddScoped(_.contract, _.concrete));

        public static List<(Type contract, Type concrete)> GetDependencies(Type[] handlerAssemblies) 
        {
            var listResult = new List<(Type contract, Type concret)>();
            foreach(var handler in handlerAssemblies)
               listResult.AddRange(RegisterHandlersAssembly(handler));
            
            return listResult;
        }
        public static List<(Type contract, Type concrete)> RegisterHandlersAssembly(Type type)
        {
            var target = type.Assembly;
            var handlers = new[] { typeof(ICommandHandler<>), typeof(IQueryHandler<,>) };
            var assemblies = target.GetReferencedAssemblies().Select(Assembly.Load).ToList();
            assemblies.Add(target);
            return (
                from concrete in assemblies.SelectMany(a => a.GetExportedTypes())
                from contract in concrete.GetInterfaces()
                where contract.IsConstructedGenericType &&
                    handlers.Contains(contract.GetGenericTypeDefinition())
                select (contract, concrete)
                    ).ToList();
        }
    }
}