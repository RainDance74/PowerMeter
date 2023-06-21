using Microsoft.UI.Xaml.Controls;

using PowerMeter.ViewModels.Menu.Payments;

namespace PowerMeter.Views.Menu.Payments;

public sealed partial class PaymentsPage : Page
{
    public PaymentsViewModel ViewModel
    {
        get;
    }

    public PaymentsPage()
    {
        ViewModel = App.GetService<PaymentsViewModel>();
        InitializeComponent();
    }
}
