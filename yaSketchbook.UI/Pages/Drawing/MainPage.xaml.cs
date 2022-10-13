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

	private void Button_Clicked(object sender, EventArgs e)
	{
    }

	private async void Slider_ValueChanged(object sender, ValueChangedEventArgs e)
	{
        var slider = sender as Slider;
		await this.BindingContext.ReloadDrawingAsync((int)slider.Value);
		
    }
}