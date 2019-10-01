using System;
using System.Threading.Tasks;
using Arch.Domain.Entities.Base;
using Arch.Infra.Data;
using Arch.Infra.Shared.Cqrs;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Arch.Handlers
{
    public class Processor : IProcessor
    {
        private readonly IServiceProvider _serviceProvider;

        public Processor(IServiceProvider serviceProvider) =>
            _serviceProvider = serviceProvider;
        public TResult Get<TResult>(IQuery<TResult> query) 
        {
            return GetDynamicHandle(typeof(IQueryHandler<,>), query.GetType(), typeof(TResult)).Handle((dynamic)query);
        }
            
        public dynamic GetDynamicHandle(Type handle, params Type[] types)  
        {
            return _serviceProvider.GetService(handle.MakeGenericType(types));
        } 
            
        public TCommand Send<TCommand>(TCommand command) where TCommand : ICommand =>
            GetDynamicHandle(typeof(ICommandHandler<>), command.GetType()).Handle((dynamic)command);

        public TCommand AutoSend<TCommand, TDomain>(TCommand command) 
            where TCommand: ICommand
            where TDomain : Entity
        {
            var archContext = _serviceProvider.GetService(typeof(ArchContext));
            var mapper = _serviceProvider.GetService(typeof(IMapper));
            var domain = ((IMapper)mapper).Map<TDomain>(command);
            var context = ((DbContext)archContext);
            context.Set<TDomain>().Add(domain);
            context.SaveChanges();

            return ((IMapper)mapper).Map<TCommand>(domain);
        }

        private ICommand SendCommand<TDomain>(ICommand command)
            where TDomain: Entity
        {
            if(command.GetType() == typeof(ICommandCreate))
            {
                return Create<TDomain>(command);
            }
            else if(command.GetType() == typeof(ICommandEdit))
            {
                return Edit<TDomain>(command);
            }
            else if(command.GetType().IsAssignableFrom(typeof(ICommandDelete)) )
            {
                return Delete<TDomain>(command);
            }
            else
            {
                throw new ArgumentException();
            }
        }

        private ICommand Create<TDomain>(ICommand command)
            where TDomain: Entity
        {
            var archContext = _serviceProvider.GetService(typeof(ArchContext));
            var mapper = _serviceProvider.GetService(typeof(IMapper));
            var domain = ((IMapper)mapper).Map<TDomain>(command);
            var context = ((DbContext)archContext);
            context.Set<TDomain>().Add(domain);
            context.SaveChanges();

            return ((IMapper)mapper).Map<ICommandCreate>(domain);
        }

        private ICommand Edit<TDomain>(ICommand command)
            where TDomain : Entity
        {
            var archContext = _serviceProvider.GetService(typeof(ArchContext));
            var mapper = _serviceProvider.GetService(typeof(IMapper));
            var domain = ((IMapper)mapper).Map<TDomain>(command);
            var context = ((DbContext)archContext);
            context.Set<TDomain>().Update(domain);
            context.SaveChanges();

            return ((IMapper)mapper).Map<ICommandCreate>(domain);
        }

        private ICommand Delete<TDomain>(ICommand command)
            where TDomain : Entity
        {
            var archContext = _serviceProvider.GetService(typeof(ArchContext));
            var context = ((DbContext)archContext);
            var entityDelete = context.Find(((dynamic)command).Id);
            context.Set<TDomain>().Remove(entityDelete);
            context.SaveChanges();

            return null;
        }
    }
}