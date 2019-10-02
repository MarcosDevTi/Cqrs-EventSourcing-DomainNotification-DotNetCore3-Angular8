using Arch.Infra.Shared.Cqrs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Arch.Cqrs.Client.Models.CustomerModels
{
    public class GetCustomer: IQuery<UpdateCustomer>
    {
        public GetCustomer(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; set; }
    }
}
