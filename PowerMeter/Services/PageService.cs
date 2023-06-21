using CommunityToolkit.Mvvm.ComponentModel;

using Microsoft.UI.Xaml.Controls;

using PowerMeter.Contracts.Services;
using PowerMeter.ViewModels;
using PowerMeter.Views;

namespace PowerMeter.Services;

public class PageService : IPageService
{
    private readonly Dictionary<string, Type> _pages = new();

    public PageService()
    {
        // MainMenu page
        Configure<MainMenuViewModel, MainMenuPage>();
        // Users pages
        Configure<ViewModels.Menu.Users.UsersViewModel, Views.Menu.Users.UsersPage>();

        Configure<ViewModels.Menu.Users.Cards.ContentGridViewModel, Views.Menu.Users.Cards.ContentGridPage>();
        Configure<ViewModels.Menu.Users.Cards.ContentGridDetailViewModel, Views.Menu.Users.Cards.ContentGridDetailPage>();

        Configure<ViewModels.Menu.Users.Managing.DataGridViewModel, Views.Menu.Users.Managing.DataGridPage>();
        // Chart page
        Configure<ChartViewModel, ChartPage>();
        // Payment page
        Configure<PaymentsViewModel, PaymentsPage>();
        // Recommendations page
        Configure<RecommendationsViewModel, RecommendationsPage>();
        // Settings page
        Configure<SettingsViewModel, SettingsPage>();
    }

    public Type GetPageType(string key)
    {
        Type? pageType;
        lock (_pages)
        {
            if (!_pages.TryGetValue(key, out pageType))
            {
                throw new ArgumentException($"Page not found: {key}. Did you forget to call PageService.Configure?");
            }
        }

        return pageType;
    }

    private void Configure<VM, V>()
        where VM : ObservableObject
        where V : Page
    {
        lock (_pages)
        {
            var key = typeof(VM).FullName!;
            if (_pages.ContainsKey(key))
            {
                throw new ArgumentException($"The key {key} is already configured in PageService");
            }

            var type = typeof(V);
            if (_pages.ContainsValue(type))
            {
                throw new ArgumentException($"This type is already configured with key {_pages.First(p => p.Value == type).Key}");
            }

            _pages.Add(key, type);
        }
    }
}
