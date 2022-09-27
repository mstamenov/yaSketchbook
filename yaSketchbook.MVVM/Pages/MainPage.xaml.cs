using yaSketchbook.MVVM.Pages.Core;
using yaSketchbook.MVVM.ViewModels;

namespace yaSketchbook.MVVM.Pages;

public partial class MainPage : BasePage<DrawingViewModel>
{
	public MainPage(DrawingViewModel viewModel) :base(viewModel)
	{
		InitializeComponent();
	}
}