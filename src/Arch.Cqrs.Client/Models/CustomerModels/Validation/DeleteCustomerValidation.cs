using Arch.Cqrs.Client.Models.CustomerModels;

namespace Arch.Cqrs.Client.Models.Customer.Validation
{
    public class DeleteCustomerValidation : CustomerCommandValidation<DeleteCustomer>
    {
        public DeleteCustomerValidation()
        {
            ValidateId();
        }
    }
}
