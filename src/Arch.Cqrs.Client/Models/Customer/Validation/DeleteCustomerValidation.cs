using System;
using System.Collections.Generic;
using System.Text;

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
