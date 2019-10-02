using Arch.Cqrs.Client.Models.Customer;
using Arch.Cqrs.Client.Models.CustomerModels;
using Arch.Infra.Data;
using Arch.Infra.Shared.Cqrs;
using AutoMapper;

namespace Arch.Handlers.Customer
{
    public class CustomerCommandHandler :
        CommandHandler<Domain.Entities.Customer>,
        ICommandHandler<CreateCustomer>
    {
        private readonly ArchContext _archContext;
        private readonly IMapper _mapper;
        public CustomerCommandHandler(ArchContext archContext, IMapper mapper)
            : base(archContext, mapper)
        {
            _archContext = archContext;
            _mapper = mapper;
        }
        public CreateCustomer Handle(CreateCustomer command)
        {
            return Add(command);
        }
    }
}