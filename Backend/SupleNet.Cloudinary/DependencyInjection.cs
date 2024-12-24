using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SupleNet.Cloudinary.Models;

namespace SupleNet.Cloudinary
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddCloudinary(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<CloudinarySettings>(configuration.GetSection("CloudinarySettings"));
            return services;
        }
    }
}
