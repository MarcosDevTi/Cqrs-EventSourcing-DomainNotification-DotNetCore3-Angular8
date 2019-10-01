using System;
using System.Collections.Generic;
using System.Text;

namespace Arch.Cqrs.Client.Models.Customer.Validation
{
    public class CreateCustomerValidation : CustomerCommandValidation<CreateCustomer>
    {
        public CreateCustomerValidation()
        {
            ValidateFirstName();
            ValidateLastName();
            ValidateBirthDate();
            ValidateEmail();
        }
    }
}
