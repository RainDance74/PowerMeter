using Microsoft.UI.Xaml.Controls;

using PowerMeter.ViewModels;

namespace PowerMeter.Views;

public sealed partial class MainMenuPage : Page
{
    public MainMenuViewModel ViewModel
    {
        get;
    }

    public MainMenuPage()
    {
        ViewModel = App.GetService<MainMenuViewModel>();
        InitializeComponent();
    }
}
