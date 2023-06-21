using PowerMeter.Core.Models;

using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

namespace PowerMeter.Views.Menu.Payments.PaymentHistory;

public sealed partial class PaymentsListDetailControl : UserControl
{
    public SampleOrder? ListDetailsMenuItem
    {
        get => GetValue(ListDetailsMenuItemProperty) as SampleOrder;
        set => SetValue(ListDetailsMenuItemProperty, value);
    }

    public static readonly DependencyProperty ListDetailsMenuItemProperty = DependencyProperty.Register("ListDetailsMenuItem", typeof(SampleOrder), typeof(PaymentsListDetailControl), new PropertyMetadata(null, OnListDetailsMenuItemPropertyChanged));

    public PaymentsListDetailControl()
    {
        InitializeComponent();
    }

    private static void OnListDetailsMenuItemPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        if (d is PaymentsListDetailControl control)
        {
            control.ForegroundElement.ChangeView(0, 0, 1);
        }
    }
}

