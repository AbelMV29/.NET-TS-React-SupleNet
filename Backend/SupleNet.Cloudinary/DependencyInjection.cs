using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SupleNet.Application.Interfaces.CloudMedia;
using SupleNet.Cloudinary.Models;
using SupleNet.Cloudinary.Services;

namespace SupleNet.Cloudinary
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddCloudinary(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<CloudinarySettings>(configuration.GetSection("CloudinarySettings"));
            services.AddScoped<ICloudMediaService, CloudinaryService>();
            return services;
        }
    }
}
