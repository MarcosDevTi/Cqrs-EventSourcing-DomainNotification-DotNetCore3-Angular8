using Arch.Cqrs.Client.Models.Customer.Validation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Arch.Cqrs.Client.Models.CustomerModels
{
    public class DeleteCustomer : CustomerCommand
    {
        public DeleteCustomer(Guid id)
        {
            Id = id;
        }
    }
}
