using Microsoft.UI.Xaml.Controls;

using PowerMeter.ViewModels;

namespace PowerMeter.Views.Menu.Users;

public sealed partial class UsersPage : Page
{
    public ViewModels.Menu.Users.UsersViewModel ViewModel
    {
        get;
    }

    public UsersPage()
    {
        ViewModel = App.GetService<ViewModels.Menu.Users.UsersViewModel>();
        InitializeComponent();
    }
}
