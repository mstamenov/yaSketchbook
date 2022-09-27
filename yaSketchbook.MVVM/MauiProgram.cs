using CommunityToolkit.Maui;
using yaSketchbook.Data.Extensions;
using yaSketchbook.MVVM.Helpers;
using yaSketchbook.MVVM.Pages;

namespace yaSketchbook.MVVM;

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
			})
			.UseMauiCommunityToolkit();

		builder.Services.RegisterRepositories();
        builder.Services.RegisterViewModels();

        builder.Services.AddTransient<MainPage>();


        return builder.Build();
	}
}
