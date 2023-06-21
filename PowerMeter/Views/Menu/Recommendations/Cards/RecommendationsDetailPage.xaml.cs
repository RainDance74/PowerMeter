using CommunityToolkit.WinUI.UI.Animations;

using PowerMeter.Contracts.Services;
using PowerMeter.ViewModels.Menu.Recommendations.Cards;

using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Navigation;

namespace PowerMeter.Views.Menu.Recommendations.Cards;

public sealed partial class RecommendationsDetailPage : Page
{
    public RecommendationsDetailViewModel ViewModel
    {
        get;
    }

    public RecommendationsDetailPage()
    {
        ViewModel = App.GetService<RecommendationsDetailViewModel>();
        InitializeComponent();
    }

    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        base.OnNavigatedTo(e);
        this.RegisterElementForConnectedAnimation("animationKeyContentGrid", itemHero);
    }

    protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
    {
        base.OnNavigatingFrom(e);
        if (e.NavigationMode == NavigationMode.Back)
        {
            var navigationService = App.GetService<INavigationService>();

            if (ViewModel.Item != null)
            {
                navigationService.SetListDataItemForNextConnectedAnimation(ViewModel.Item);
            }
        }
    }
}
