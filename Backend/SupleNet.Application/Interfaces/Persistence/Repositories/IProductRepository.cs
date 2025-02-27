﻿using SupleNet.Application.Interfaces.Persistence.Repositories.Common;
using SupleNet.Domain.Entities;

namespace SupleNet.Application.Interfaces.Persistence.Repositories
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        IQueryable<Product> GetAllReadOnlyIncludeSaleDetailsAsync();
    }
}
