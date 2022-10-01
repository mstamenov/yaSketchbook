using yaSketchbook.UI.Pages.Core;
using yaSketchbook.ViewModels;

namespace yaSketchbook.UI.Pages;

public partial class MainPage : BasePage<DrawingViewModel>
{
	public MainPage(DrawingViewModel viewModel) :base(viewModel)
	{
		InitializeComponent();
	}
}