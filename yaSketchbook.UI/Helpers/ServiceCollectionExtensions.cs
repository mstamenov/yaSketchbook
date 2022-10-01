using yaSketchbook.UI.Pages;

namespace yaSketchbook.UI.Helpers;

public static class ServiceCollectionExtensions
{   
    public static IServiceCollection RegisterViews(this IServiceCollection services)
    {
        services.AddTransient<MainPage>();

        return services;
    }
}
