using System;
using System.Collections.Generic;
using Arch.Infra.Shared.Cqrs;
using Moq;
using Xunit;

namespace Arch.Handlers.Tests
{
    public class ProcessorTests
    {
        private Mock<IServiceProvider> _serviceProviderMock;
        private Processor _processor;

        public ProcessorTests() 
        {
            _serviceProviderMock = new Mock<IServiceProvider>();
            _processor = new Processor(_serviceProviderMock.Object);
        }

        [Fact]
        public void SendTests() 
        {
            _serviceProviderMock.Setup(_ => _.GetService(typeof(ICommandHandler<CreateObject>))).Returns(new ObjectCommandHandler());
            var result = _processor.Send(new CreateObject());
            Assert.True(result.Name == "Test Name");
        }

        [Fact]
        public void GetTests()
        {
            var objectQueryHandlermock = new Mock<ObjectQueryHandler>();

            _serviceProviderMock.Setup(_ => _.GetService(typeof(IQueryHandler<GetObjects, IEnumerable<CreateObject>>))).Returns(new ObjectQueryHandler());
            var result = _processor.Get(new GetObjects());
            Assert.Contains(result, _ => _.Name == "Test Name");
        }

        [Fact]
        public void GetDynamicHandleTest() 
        {
            _processor.GetDynamicHandle(typeof(ICommandHandler<>), typeof(CreateObject));
            _serviceProviderMock.Verify(_ => _.GetService(typeof(ICommandHandler<CreateObject>)));
        }
    }
}