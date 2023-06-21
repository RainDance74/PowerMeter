using CommunityToolkit.Mvvm.ComponentModel;

using PowerMeter.Contracts.ViewModels;
using PowerMeter.Core.Contracts.Services;
using PowerMeter.Core.Models;

namespace PowerMeter.ViewModels.Menu.Recommendations.Cards;

public partial class RecommendationsDetailViewModel : ObservableRecipient, INavigationAware
{
    private readonly ISampleDataService _sampleDataService;

    [ObservableProperty]
    private SampleOrder? item;

    public RecommendationsDetailViewModel(ISampleDataService sampleDataService)
    {
        _sampleDataService = sampleDataService;
    }

    public async void OnNavigatedTo(object parameter)
    {
        if (parameter is long orderID)
        {
            var data = await _sampleDataService.GetContentGridDataAsync();
            Item = data.First(i => i.OrderID == orderID);
        }
    }

    public void OnNavigatedFrom()
    {
    }
}
