using PowerMeter.ViewModels.Menu.Recommendations.Cards;

using Microsoft.UI.Xaml.Controls;

namespace PowerMeter.Views.Menu.Recommendations.Cards;

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

