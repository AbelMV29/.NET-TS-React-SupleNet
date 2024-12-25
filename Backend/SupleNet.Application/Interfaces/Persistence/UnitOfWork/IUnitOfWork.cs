namespace SupleNet.Application.Interfaces.Persistence.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        Task BeginTransactionAsync();
        Task CommitTransactionAsync();
        Task RollbackTransactionAsync();
    }
}
