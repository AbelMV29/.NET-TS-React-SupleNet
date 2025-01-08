using SupleNet.Application.Interfaces.Persistence.Repositories.Common;
using SupleNet.Domain.Entities;

namespace SupleNet.Application.Interfaces.Persistence.Repositories
{
    public interface IItemCartRepository : IGenericRepository<ItemCart>
    {
        Task<ItemCart?> GetByProductIdUser(Guid productId, Guid appUserId);
        Task<ItemCart[]> GetCartUser(Guid appUserId);
    }
}
