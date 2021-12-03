using Application.Puzzles;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddSingleton<Day01>();
            services.AddSingleton<Day02>();

            return services;
        }
    }
}