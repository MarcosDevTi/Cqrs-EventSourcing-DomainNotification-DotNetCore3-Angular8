using System.Collections.Generic;
using Arch.Infra.Shared.Cqrs;
using Arch.Infra.Shared.Paging;
using Arch.Cqrs.Client.Models.Customer;

namespace Arch.Cqrs.Client.Models.CustomerModels
{
    public class CustomersQuery: IQuery<PagedResult<CustomerItem>>
    {
        public Paging<Domain.Entities.Customer> Paging { get; set; }
    }
}