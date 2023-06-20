using Microsoft.UI.Xaml.Controls;

using PowerMeter.ViewModels;

namespace PowerMeter.Views;

public sealed partial class UsersPage : Page
{
    public UsersViewModel ViewModel
    {
        get;
    }

    public UsersPage()
    {
        ViewModel = App.GetService<UsersViewModel>();
        InitializeComponent();
    }
}
