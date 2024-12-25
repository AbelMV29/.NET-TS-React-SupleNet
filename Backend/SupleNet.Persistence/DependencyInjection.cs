using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using SupleNet.Application.Interfaces.Persistence.Identity;
using SupleNet.Application.Interfaces.Persistence.Repositories;
using SupleNet.Application.Interfaces.Persistence.UnitOfWork;
using SupleNet.Domain.Entities;
using SupleNet.Persistence.Data;
using SupleNet.Persistence.DataAccess;
using SupleNet.Persistence.DataAccess.Repositories;
using SupleNet.Persistence.Models;
using SupleNet.Persistence.Services;
using System.Text;

namespace SupleNet.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));

            services.AddDbContext<SupleNetContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("SupleNetDatabase"),
                    b => b.MigrationsAssembly(typeof(SupleNetContext).Assembly.FullName));
            });

            services.AddIdentity<AppUser, IdentityRole<Guid>>(identityOptions =>
            {
                identityOptions.SignIn.RequireConfirmedEmail = true;
                identityOptions.Password.RequiredLength = 8;
            }).AddEntityFrameworkStores<SupleNetContext>()
            .AddDefaultTokenProviders();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(config =>
            {
                config.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSettings:Key"]!)),
                    ValidateIssuer = true,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidIssuer = configuration["JwtSettings:Issuer"],
                    ValidAudience = configuration["JwtSettings:Audience"]

                };
            });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("Customer", policy => policy.RequireRole("Customer"));
                options.AddPolicy("Admin", policy => policy.RequireRole("Admin"));
            });

            

            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<UserManager<AppUser>>();
            services.AddScoped<SignInManager<AppUser>>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IGalleryRepository, GalleryRepository>();
            services.AddScoped<IBrandRepository, BrandRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();


            return services;
        }

    }
}
