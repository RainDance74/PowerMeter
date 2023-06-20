using Microsoft.UI.Xaml.Controls;

using PowerMeter.ViewModels;

namespace PowerMeter.Views;

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
