
namespace yaSketchbook.ViewModels.Helpers;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection RegisterViewModels(this IServiceCollection services)
    {
        services.AddTransient<DrawingViewModel>();

        return services;
    }
}
