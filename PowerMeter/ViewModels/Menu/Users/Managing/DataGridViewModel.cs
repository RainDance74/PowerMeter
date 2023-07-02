using System.Collections.ObjectModel;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;
using PowerMeter.Contracts.ViewModels;
using PowerMeter.Core.Contracts.Services;
using PowerMeter.Core.Models;

namespace PowerMeter.ViewModels.Menu.Users.Managing;

public partial class DataGridViewModel : ObservableRecipient
{
    public ObservableCollection<User> Source { get; } = new ObservableCollection<User>();
    public void PageLoadedCommand() => GetDataAsync();

    public async void GetDataAsync()
    {
        Source.Clear();

        // Don't make the program wait until the DBContext will be generated with await
        var db = await Task.Run(() => new Core.Data.PowerMeterContext());
        // TODO: Add roles checking
        var data = await db.Users.Include(u => u.Department)
                                 .Include(u => u.Office)
                                 .ToListAsync();

        // Add every user in the same time 👇
        await Task.WhenAll(data.Select(item => { Source.Add(item); return Task.CompletedTask; }));
    }

    public void OnNavigatedFrom()
    {
    }
}