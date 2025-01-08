using Microsoft.EntityFrameworkCore;
using SupleNet.Application.Interfaces.Persistence.Repositories;
using SupleNet.Domain.Entities;
using SupleNet.Persistence.Data;
using SupleNet.Persistence.DataAccess.Repositories.Common;

namespace SupleNet.Persistence.DataAccess.Repositories
{
    internal class ItemCartRepository : GenericRepository<ItemCart>, IItemCartRepository
    {
        public ItemCartRepository(SupleNetContext context) : base(context)
        {
        }

        public async Task<ItemCart?> GetByProductIdUser(Guid productId, Guid appUserId)
        {
            return await GetAll().FirstOrDefaultAsync(i => i.ProductId == productId && i.CreatedBy == appUserId);
        }

        public async Task<ItemCart[]> GetCartUser(Guid appUserId)
        {
            return await GetAllReadOnly()
                .Where(i => i.CreatedBy == appUserId)
                .Include(i => i.Product)
                .ToArrayAsync();
        }
    }
}
