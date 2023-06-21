using Microsoft.UI.Xaml.Controls;

using PowerMeter.ViewModels.Menu.Recommendations;

namespace PowerMeter.Views.Menu.Recommendations;

public sealed partial class RecommendationsPage : Page
{
    public RecommendationsViewModel ViewModel
    {
        get;
    }

    public RecommendationsPage()
    {
        ViewModel = App.GetService<RecommendationsViewModel>();
        InitializeComponent();
    }
}
