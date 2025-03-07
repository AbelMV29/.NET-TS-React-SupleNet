﻿using SupleNet.Application.Interfaces.Persistence.Repositories.Common;
using SupleNet.Domain.Entities;

namespace SupleNet.Application.Interfaces.Persistence.Repositories
{
    public interface ICategoryRepository : IGenericRepository<Category>, IExistByNameRepository<Category>
    {
    }
}
