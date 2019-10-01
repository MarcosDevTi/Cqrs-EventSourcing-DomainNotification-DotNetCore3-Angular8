using System;
using System.Collections.Generic;
using System.Text;

namespace Arch.Cqrs.Client.Models.Customer.Validation
{
    public class UpdateCustomerValidation : CustomerCommandValidation<UpdateCustomer>
    {
        public UpdateCustomerValidation()
        {
            ValidateId();
            ValidateFirstName();
            ValidateLastName();
            ValidateBirthDate();
            ValidateEmail();
        }
    }
}
