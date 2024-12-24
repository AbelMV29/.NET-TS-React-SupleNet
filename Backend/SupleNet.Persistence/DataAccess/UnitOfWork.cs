using Microsoft.EntityFrameworkCore.Storage;
using SupleNet.Application.Interfaces.Persistence.UnitOfWork;
using SupleNet.Persistence.Data;

namespace SupleNet.Persistence.DataAccess
{
    internal class UnitOfWork : IUnitOfWork
    {
        private readonly SupleNetContext _context;
        private IDbContextTransaction _transaction;

        public UnitOfWork(SupleNetContext context)
        {
            _context = context;
        }

        public async Task BeginTransactionAsync()
        {
            _transaction = await _context.Database.BeginTransactionAsync();
        }

        public async Task CommitTransactionAsync()
        {
            if (_transaction != null)
            {
                await _context.SaveChangesAsync();
                await _transaction.CommitAsync();
                await _transaction.DisposeAsync();
            }
        }

        public void Dispose()
        {
            _transaction?.Dispose();
        }

        public async Task RollbackTransactionAsync()
        {
            if(_transaction is not null)
            {
                await _transaction.RollbackAsync();
                await _transaction.DisposeAsync();
            }
        }
    }
}
