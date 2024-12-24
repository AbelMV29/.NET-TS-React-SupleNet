using Microsoft.Extensions.DependencyInjection;
using FluentValidation;

namespace SupleNet.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly);

            services.AddMediatR(config =>
            {
                config.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly);
            });

            return services;
        }

    }
}
