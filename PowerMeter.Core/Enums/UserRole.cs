using System.ComponentModel;

namespace PowerMeter.Core.Enums;

// TODO: Multiple languages support
public enum UserRole
{
    [Description("Super Admin")]
    SAdmin,
    [Description("Admin")]
    Admin,
    [Description("Accountant")]
    Accountant,
    [Description("User")]
    User
}