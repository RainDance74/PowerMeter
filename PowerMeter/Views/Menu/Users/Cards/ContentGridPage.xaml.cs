using PowerMeter.ViewModels.Menu.Users.Cards;

using Microsoft.UI.Xaml.Controls;

namespace PowerMeter.Views.Menu.Users.Cards;

public sealed partial class ContentGridPage : Page
{
    public ContentGridViewModel ViewModel
    {
        get;
    }

    public ContentGridPage()
    {
        ViewModel = App.GetService<ContentGridViewModel>();
        InitializeComponent();
    }
}
