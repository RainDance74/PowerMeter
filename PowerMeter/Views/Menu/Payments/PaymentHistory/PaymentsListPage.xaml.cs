using CommunityToolkit.WinUI.UI.Controls;

using PowerMeter.ViewModels.Menu.Payments.PaymentsListViewModel;

using Microsoft.UI.Xaml.Controls;

namespace PowerMeter.Views.Menu.Payments.PaymentHistory;

public sealed partial class PaymentsListPage : Page
{
    public PaymentsListViewModel ViewModel
    {
        get;
    }

    public PaymentsListPage()
    {
        ViewModel = App.GetService<PaymentsListViewModel>();
        ViewModel.GetDataAsync();
        InitializeComponent();
    }

    private void OnViewStateChanged(object sender, ListDetailsViewState e)
    {
        if (e == ListDetailsViewState.Both)
        {
            ViewModel.EnsureItemSelected();
        }
    }
}
