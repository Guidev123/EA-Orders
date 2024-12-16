namespace Orders.Core.Repositories
{
    public interface IOrderRepository
    {
        IUnitOfWork UnitOfWork { get; }
    }
}
