﻿using Microsoft.EntityFrameworkCore;
using SupleNet.Application.Interfaces.Persistence.Repositories;
using SupleNet.Domain.Entities;
using SupleNet.Persistence.Data;
using SupleNet.Persistence.DataAccess.Repositories.Common;

namespace SupleNet.Persistence.DataAccess.Repositories
{
    internal class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(SupleNetContext context) : base(context)
        {
        }

        public IQueryable<Product> GetAllReadOnlyIncludeSaleDetailsAsync()
        {
            return _context.Products.AsNoTracking().Include(p => p.SaleDetails).AsQueryable<Product>();
        }
    }
}
