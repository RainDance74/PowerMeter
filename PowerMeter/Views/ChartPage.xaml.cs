using Microsoft.UI.Xaml.Controls;

using PowerMeter.ViewModels;

namespace PowerMeter.Views;

public sealed partial class ChartPage : Page
{
    public ChartViewModel ViewModel
    {
        get;
    }

    public ChartPage()
    {
        ViewModel = App.GetService<ChartViewModel>();
        InitializeComponent();
    }
}
