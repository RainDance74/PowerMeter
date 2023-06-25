using CommunityToolkit.Mvvm.ComponentModel;
using PowerMeter.Contracts.ViewModels;
using PowerMeter.Core.Models;

namespace PowerMeter.ViewModels.Menu.Users.Cards;

public partial class ContentGridDetailViewModel : ObservableRecipient, INavigationAware
{
    [ObservableProperty]
    private User? item;

    public void OnNavigatedTo(object parameter)
    {
        if (parameter is User and not null)
        {
            Item = parameter as User;
            
        }
    }

    public void OnNavigatedFrom()
    {
    }
}
