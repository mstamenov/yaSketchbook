using CommunityToolkit.Maui;
using yaSketchbook.Data.Extensions;
using yaSketchbook.UI.Helpers;
using yaSketchbook.ViewModels.Helpers;

namespace yaSketchbook.UI
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                }).UseMauiCommunityToolkit();

            builder.Services.RegisterRepositories();
            builder.Services.RegisterViewModels();
            builder.Services.RegisterViews();

            return builder.Build();
        }
    }
}