namespace Orders.Core.Repositories
{
    public interface IVoucherRepository
    {
        IUnitOfWork UnitOfWork { get; }
    }
}
