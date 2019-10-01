using System.Threading.Tasks;

namespace Arch.Infra.Shared.Cqrs
{
    public interface ICommandHandler<TCommand>
        where TCommand: ICommand
    {
         TCommand Handle(TCommand command);
    }
}