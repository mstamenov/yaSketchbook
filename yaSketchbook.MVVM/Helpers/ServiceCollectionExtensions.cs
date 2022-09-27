using yaSketchbook.MVVM.ViewModels;
using yaSketchbook.MVVM.Pages;

namespace yaSketchbook.MVVM.Helpers;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection RegisterViewModels(this IServiceCollection services)
    {
        services.AddTransient<DrawingViewModel>();

        return services;
    }
    
    public static IServiceCollection RegisterViews(this IServiceCollection services)
    {
        services.AddTransient<MainPage>();

        return services;
    }
}
