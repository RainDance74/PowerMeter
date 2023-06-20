using Microsoft.UI.Xaml.Controls;

using PowerMeter.ViewModels;

namespace PowerMeter.Views;

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
