using System;
using System.Collections.Generic;
using System.Linq;
using Arch.Handlers.Extensions;
using Arch.Infra.Shared.Cqrs;
using Xunit;

namespace Arch.Handlers.Tests
{
    public class CqrsExtensionsTests
    {
        [Fact]
        public void RegisterHandlersAssemblyICommandHandlerTest()
        {
            var result = CqrsExtensions.RegisterHandlersAssembly(typeof(ObjectCommandHandler));
            var assResult = (typeof(ICommandHandler<CreateObject>) , typeof(ObjectCommandHandler)).GetType();
            Assert.Contains(assResult, result.Select(_ => _.GetType()));
        }

        [Fact]
        public void RegisterHandlersAssemblyIQuerydHandlerTest()
        {
            var result = CqrsExtensions.RegisterHandlersAssembly(typeof(ObjectCommandHandler));
            var assResult = (typeof(IQueryHandler<GetObjects, IEnumerable<CreateObject>>) , typeof(ObjectQueryHandler)).GetType();
            var rre = result.Select(_ => _.GetType()).Contains(assResult);
            Assert.Contains(assResult, result.Select(_ => _.GetType()));
        }

        [Fact]
        public void GetDependenciesTest() 
        {
           var result = CqrsExtensions.GetDependencies(new Type[] {typeof(CreateObject)});
           var expetedResult = new List<(Type contract, Type concrete)>
           {
               (typeof(IQueryHandler<GetObjects, IEnumerable<CreateObject>>), typeof(ObjectQueryHandler)),
               (typeof(ICommandHandler<CreateObject>), typeof(ObjectCommandHandler))
           };
           var reponse = true;
           expetedResult.ForEach(_ => {
               if(!result.Contains(_)) reponse = false;
           });
           Assert.True(reponse);
        }
    }
}
