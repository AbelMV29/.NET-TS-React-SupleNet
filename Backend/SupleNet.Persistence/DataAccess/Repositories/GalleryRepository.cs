using SupleNet.Application.Interfaces.Persistence.Repositories;
using SupleNet.Domain.Entities;
using SupleNet.Persistence.Data;
using SupleNet.Persistence.DataAccess.Repositories.Common;

namespace SupleNet.Persistence.DataAccess.Repositories
{
    internal class GalleryRepository : GenericRepository<Gallery>, IGalleryRepository
    {
        public GalleryRepository(SupleNetContext context) : base(context)
        {
        }
    }
}
