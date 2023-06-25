using System.Reflection;
using System.Runtime.Serialization;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace PowerMeter.Core.Helpers;
public static class EnumHelper
{
    public static ValueConverter<TEnum, string> CreateEnumToStringConverter<TEnum>()
    where TEnum : Enum
    {
        return new ValueConverter<TEnum, string>(
            v => v.ToFriendlyString(),
            v => v.FromFriendlyString<TEnum>());
    }

    public static string ToFriendlyString<T>(this T @enum)
        where T : Enum
    {
        // Get the type
        var type = @enum.GetType();
        // Get the member info
        var memberInfo = type.GetMember(@enum.ToString());
        // If there is no member info, return the string value
        if (memberInfo.Length <= 0) return @enum.ToString();
        // Get the attribute
        var attribute = memberInfo[0].GetCustomAttribute<EnumMemberAttribute>(false);

        // Return the friendly value
        return attribute?.Value ?? @enum.ToString();
    }

    public static T FromFriendlyString<T>(this string @string)
        where T : Enum
    {
        // Get the type
        var type = typeof(T);
        // Get the member info
        var memberInfo = type.GetMembers()
            .FirstOrDefault(x => x.GetCustomAttribute<EnumMemberAttribute>()?.Value == @string);
        // If there is no member info, return the string value
        if (memberInfo == null)
        {
            return (T)Enum.Parse(type, @string);
        }

        // Return the friendly value
        return (T)Enum.Parse(type, memberInfo.Name);
    }
}
