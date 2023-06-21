using System.Collections.ObjectModel;

using CommunityToolkit.Mvvm.ComponentModel;

using PowerMeter.Contracts.ViewModels;
using PowerMeter.Core.Contracts.Services;
using PowerMeter.Core.Models;

namespace PowerMeter.ViewModels.Menu.Payments.PaymentsListViewModel;

public partial class PaymentsListViewModel : ObservableRecipient
{
    private readonly ISampleDataService _sampleDataService;

    [ObservableProperty]
    private SampleOrder? selected;

    public ObservableCollection<SampleOrder> SampleItems { get; private set; } = new ObservableCollection<SampleOrder>();

    public PaymentsListViewModel(ISampleDataService sampleDataService)
    {
        _sampleDataService = sampleDataService;
    }

    public async void GetDataAsync()
    {
        SampleItems.Clear();

        // TODO: Replace with real data.
        var data = await _sampleDataService.GetListDetailsDataAsync();

        foreach (var item in data)
        {
            SampleItems.Add(item);
        }
    }

    public void EnsureItemSelected()
    {
        Selected ??= SampleItems.First();
    }
}
