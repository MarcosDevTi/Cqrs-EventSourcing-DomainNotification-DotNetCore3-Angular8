namespace Arch.Infra.Shared.Cqrs
{
    public interface IQueryHandler<in TQuery, out TResult>
        where TQuery: IQuery<TResult>
    {
         TResult Handle(TQuery query);
    }
}