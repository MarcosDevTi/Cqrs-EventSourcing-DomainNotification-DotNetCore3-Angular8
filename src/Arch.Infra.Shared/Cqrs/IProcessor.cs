using Arch.Domain.Entities.Base;
using System.Threading.Tasks;

namespace Arch.Infra.Shared.Cqrs
{
    public interface IProcessor
    {
         TCommand Send<TCommand>(TCommand command) where TCommand: ICommand;
        TCommand AutoSend<TCommand, TDomain>(TCommand command)
            where TCommand : ICommand
            where TDomain : Entity;
         TResult Get<TResult>(IQuery<TResult> query);
    }
}