using System.ComponentModel;

namespace PowerMeter.Core.Enums;

// TODO: Multiple languages support
public enum UserStatus
{
    [Description("Active")]
    Active,
    [Description("Inactive")]
    Inactive,
    [Description("Suspended")]
    Suspended
}