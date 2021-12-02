using Domain.Infrastructure;
using InputFileIntegration.Impl;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddFileReadingIntegration(this IServiceCollection services)
        {
            services.AddScoped<IInputFileReadingService, InputFileReadingService>();

            return services;
        }
    }
}