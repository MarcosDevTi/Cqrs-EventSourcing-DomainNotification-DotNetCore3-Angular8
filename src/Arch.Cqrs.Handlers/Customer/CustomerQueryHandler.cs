using Arch.Cqrs.Client.Models.Customer;
using Arch.Cqrs.Client.Models.CustomerModels;
using Arch.Infra.Data;
using Arch.Infra.Shared.Cqrs;
using Arch.Infra.Shared.Paging;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Arch.Cqrs.Handlers.Customer
{
    public class CustomerQueryHandler :
        IQueryHandler<CustomersQuery, PagedResult<CustomerItem>>,
        IQueryHandler<GetCustomer, UpdateCustomer>
    {
        private readonly ArchContext _archContext;
        private readonly IMapper _mapper;
        public CustomerQueryHandler(ArchContext archContext, IMapper mapper)
        {
            _archContext = archContext;
            _mapper = mapper;
        }

        public PagedResult<CustomerItem> Handle(CustomersQuery query)
        {
            return _archContext.Customers.GetPagedResult<Domain.Entities.Customer, CustomerItem>(_mapper, query.Paging);
        }

        public UpdateCustomer Handle(GetCustomer query)
        {
            return _mapper.Map<UpdateCustomer>(_archContext.Customers.Find(query.Id));
        }
    }
}
