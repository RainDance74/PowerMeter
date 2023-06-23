using System.Collections.ObjectModel;
using System.Windows.Input;

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;
using PowerMeter.Contracts.Services;
using PowerMeter.Contracts.ViewModels;
using PowerMeter.Core.Contracts.Services;
using PowerMeter.Core.Models;
using PowerMeter.Core.Services;

namespace PowerMeter.ViewModels.Menu.Users.Cards;

public partial class ContentGridViewModel : ObservableRecipient
{
    private readonly INavigationService _navigationService;

    public ObservableCollection<User> Source { get; } = new ObservableCollection<User>();

    public ContentGridViewModel(INavigationService navigationService)
    {
        _navigationService = navigationService;
    }

    public void PageLoadedCommand() => GetDataAsync();

    public async void GetDataAsync()
    {
        Source.Clear();

        // Don't make the program wait until the DBContext will be generated with await
        var db = await Task.Run(() => new Core.Data.PowerMeterContext());
        var data = await db.Users.ToListAsync();
        // Add every user in the same time 👇
        await Task.WhenAll(data.Select(item => { Source.Add(item); return Task.CompletedTask; }));
    }

    [RelayCommand]
    private void OnItemClick(User? clickedItem)
    {
        if (clickedItem != null)
        {
            _navigationService.SetListDataItemForNextConnectedAnimation(clickedItem);
            _navigationService.NavigateTo(typeof(ContentGridDetailViewModel).FullName!, clickedItem.UserId);
        }
    }
}
