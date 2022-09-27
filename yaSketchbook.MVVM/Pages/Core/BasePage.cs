using System.Diagnostics;
using yaSketchbook.MVVM.ViewModels;

namespace yaSketchbook.MVVM.Pages.Core;

public abstract class BasePage<TViewModel> : BasePage where TViewModel : BaseViewModel
{
    public BasePage(TViewModel viewModel):base(viewModel)
    {
    }

    public new TViewModel BindingContext => (TViewModel)base.BindingContext;
}

public abstract class BasePage : ContentPage
{
    protected BasePage(object viewModel)
    {
        BindingContext = viewModel;
        Padding = 12;

        if (string.IsNullOrWhiteSpace(Title))
        {
            Title = GetType().Name;
        }
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        Debug.WriteLine($"OnAppearing: {Title}");
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();

        Debug.WriteLine($"OnDisappearing: {Title}");
    }
}
