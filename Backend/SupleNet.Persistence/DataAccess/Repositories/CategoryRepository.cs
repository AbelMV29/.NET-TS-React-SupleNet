using SupleNet.Application.Interfaces.Persistence.Repositories;
using SupleNet.Domain.Entities;
using SupleNet.Persistence.Data;
using SupleNet.Persistence.DataAccess.Repositories.Common;

namespace SupleNet.Persistence.DataAccess.Repositories
{
    internal class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(SupleNetContext context) : base(context)
        {
        }
    }
}
