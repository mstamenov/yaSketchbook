using CommunityToolkit.Maui.Views;
using System.Diagnostics;
using yaSketchbook.UI.Pages.Core;
using yaSketchbook.ViewModels;

namespace yaSketchbook.UI.Pages;

public partial class MainPage : BasePage<DrawingViewModel>
{
	public MainPage(DrawingViewModel viewModel) : base(viewModel)
	{
		InitializeComponent();
	}

    protected async override void OnAppearing()
    {
        await this.BindingContext.GetSavedDrawingMaxId();
        base.OnAppearing();
    }

	private async void Slider_ValueChanged(object sender, ValueChangedEventArgs e)
	{
		var slider = sender as Slider;
		int sliderValue = (int)slider.Value;

        if(sliderValue > 0)
		{
            await this.BindingContext.ReloadDrawingAsync(sliderValue);
        }
    }
}