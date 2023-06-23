using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.EntityFrameworkCore;
using PowerMeter.Contracts.ViewModels;
using PowerMeter.Core.Contracts.Services;
using PowerMeter.Core.Models;

namespace PowerMeter.ViewModels.Menu.Users.Cards;

public partial class ContentGridDetailViewModel : ObservableRecipient, INavigationAware
{
    [ObservableProperty]
    private User? item;

    public async void OnNavigatedTo(object parameter)
    {
        if (parameter is int Id)
        {
            // Don't make the program wait until the DBContext will be generated with await
            var db = await Task.Run(() => new Core.Data.PowerMeterContext());
            Item = await db.Users.Include(u => u.Department)
                                 .FirstOrDefaultAsync(i => i.UserId == Id);
        }
    }

    public void OnNavigatedFrom()
    {
    }
}
