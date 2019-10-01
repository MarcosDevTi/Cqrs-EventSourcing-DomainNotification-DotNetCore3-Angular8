using Arch.Domain.Entities.Base;
using Arch.Infra.Data;
using Arch.Infra.Shared.Cqrs;
using AutoMapper;

namespace Arch.Handlers
{
    public abstract class CommandHandler<TDomain>
            where TDomain: Entity
    {
        private readonly ArchContext _archContext;
        private readonly IMapper _mapper;
        public CommandHandler(ArchContext archContext, IMapper mapper)
        {
            _archContext = archContext;
            _mapper = mapper;
        }
        protected TCommand Add<TCommand>(TCommand command)
            where TCommand : ICommand
        {
            var domain = _mapper.Map<TDomain>(command);
            _archContext.Set<TDomain>().Add(domain);
            _archContext.SaveChanges();
            return _mapper.Map<TCommand>(domain);
        }
    }
}
