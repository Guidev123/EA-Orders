namespace Orders.Core.Repositories
{
    public interface IUnitOfWork
    {
        Task<bool> CommitAsync();
    }
}
