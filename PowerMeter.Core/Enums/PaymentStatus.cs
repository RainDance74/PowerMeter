using System.Runtime.Serialization;

namespace PowerMeter.Core.Enums;

public enum PaymentStatus
{
    [EnumMember(Value = "In Progress")]
    InProgress,
    [EnumMember(Value = "Confirmation")]
    Confirmation,
    [EnumMember(Value = "Canceled")]
    Canceled,
    [EnumMember(Value = "Finished")]
    Done
}