using System.Runtime.Serialization;

namespace PowerMeter.Core.Enums;

public enum UserRole
{
    [EnumMember(Value = "Super Admin")]
    SAdmin,
    [EnumMember(Value = "Admin")]
    Admin,
    [EnumMember(Value = "Accountant")]
    Accountant,
    [EnumMember(Value = "User")]
    User
}