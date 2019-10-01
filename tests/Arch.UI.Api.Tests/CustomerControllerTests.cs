using Arch.UI.Api.Controllers;
using Arch.Infra.Shared.Cqrs;
using Moq;
using Xunit;
using Arch.Cqrs.Client.Models.Customer;

namespace Arch.UI.Api.Tests
{
    public class CustomerControllerTests
    {
        [Fact]
        public void CreateCustomerTest()
        {
            var processorMock = new Mock<IProcessor>();
            var createCustomer = new CreateCustomer { FirstName = "Marcos" };
            processorMock.Setup(_ => _.Send(createCustomer)).Returns(createCustomer);
            var customerController = new CustomerController(processorMock.Object);
            customerController.CreateCustomer(createCustomer);
            processorMock.Verify(_ => _.Send(createCustomer));
        }
    }
}
