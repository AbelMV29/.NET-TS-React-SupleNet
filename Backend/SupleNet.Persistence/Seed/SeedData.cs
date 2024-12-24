using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SupleNet.Domain.Entities;

namespace SupleNet.Persistence.Seed
{
    internal static class SeedData
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityRole<Guid>>()
                .HasData(new IdentityRole<Guid> { Id = new Guid("c38c5327-2355-4199-8648-bf6f09097827"), Name = "Customer", NormalizedName = "Customer" },
                         new IdentityRole<Guid> { Id = new Guid("eea8d50f-bb2f-4ca4-a136-6b399b5856b8"), Name = "Admin", NormalizedName ="Admin"});

            modelBuilder.Entity<AppUser>()
                .HasData(new AppUser
                {
                    Id = new Guid("cd82a514-cbda-4e3e-a9ce-e0545898d0ba"),
                    Email = "admin@mail.com",
                    NormalizedEmail = "admin@mail.com",
                    Name = "Admin",
                    LastName = "User",
                    EmailConfirmed = true,
                    UserName = "admin@mail.com",
                    NormalizedUserName = "admin@mail.com",
                    SecurityStamp = Guid.NewGuid().ToString(),
                    PhoneNumber = "+549111234123",
                    PasswordHash = new PasswordHasher<AppUser>().HashPassword(null, "Abcd1234!")
                });;

            modelBuilder.Entity<IdentityUserRole<Guid>>()
                .HasData(new IdentityUserRole<Guid>
                {
                    RoleId = new Guid("eea8d50f-bb2f-4ca4-a136-6b399b5856b8"),
                    UserId = new Guid("cd82a514-cbda-4e3e-a9ce-e0545898d0ba")
                });
        }
    }
}
