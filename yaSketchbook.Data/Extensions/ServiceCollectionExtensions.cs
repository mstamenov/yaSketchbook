using yaSketchbook.Data.Repositories;

namespace yaSketchbook.Data.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection RegisterRepositories(this IServiceCollection services)
        {
            services.AddTransient<IDrawingsRepository, DrawingsRepository>();

            return services;
        }
    }
}
