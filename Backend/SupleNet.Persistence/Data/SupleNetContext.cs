using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SupleNet.Domain.Entities;
using SupleNet.Persistence.Seed;

namespace SupleNet.Persistence.Data
{
    public class SupleNetContext : IdentityDbContext<AppUser, IdentityRole<Guid>, Guid>
    {
        public SupleNetContext(DbContextOptions<SupleNetContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Gallery> Galleries { get; set; }
        public DbSet<ItemCart> ItemCarts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<SaleDetail> SaleDetails { get; set; }
        public DbSet<Valoration> Valorations { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Seed();
        }
    }
}
