using System.ComponentModel;

namespace PowerMeter.Core.Enums;

// TODO: Multiple languages support
public enum PaymentStatus
{
    [Description("In Progress")]
    InProgress,
    [Description("Confirmation")]
    Confirmation,
    [Description("Canceled")]
    Canceled,
    [Description("Finished")]
    Done
}