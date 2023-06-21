using PowerMeter.ViewModels.Menu.Users.Managing;

using Microsoft.UI.Xaml.Controls;


namespace PowerMeter.Views.Menu.Users.Managing;
public sealed partial class DataGridPage : Page
{
    public DataGridViewModel ViewModel
    {
        get;
    }

    public DataGridPage()
    {
        ViewModel = App.GetService<DataGridViewModel>();
        InitializeComponent();
    }
}
