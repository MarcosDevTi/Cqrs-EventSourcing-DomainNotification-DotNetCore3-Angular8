using System.Collections.Generic;
using Arch.Infra.Shared.Cqrs;
using Arch.Infra.Shared.Paging;

namespace Arch.Cqrs.Client.Models.Customer
{
    public class CustomersQuery: IQuery<PagedResult<CustomerItem>>
    {
        public Paging<Domain.Entities.Customer> Paging { get; set; }
    }
}