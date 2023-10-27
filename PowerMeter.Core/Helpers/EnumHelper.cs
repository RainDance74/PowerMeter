using System.ComponentModel;
using System.Reflection;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace PowerMeter.Core.Helpers;
public static class EnumHelper
{
    public static ValueConverter<TEnum, string> CreateEnumToStringConverter<TEnum>()
    where TEnum : Enum
    {
        return new ValueConverter<TEnum, string>(
            v => v.ToDescriptionString(),
            v => v.FromDescriptionString<TEnum>());
    }

    public static string ToDescriptionString<T>(this T @enum)
        where T : Enum
    {
        var enumType = @enum.GetType();
        var memberInfo = enumType.GetMember(@enum.ToString());
        if (memberInfo.Length <= 0) return @enum.ToString();
        var descriptionAttribute = (DescriptionAttribute)memberInfo[0].GetCustomAttribute(typeof(DescriptionAttribute), false);
        return descriptionAttribute == null ? @enum.ToString() : descriptionAttribute.Description;
    }

    public static T FromDescriptionString<T>(this string @string)
        where T : Enum
    {
        var enumType = typeof(T);
        var memberInfo = enumType.GetMembers();
        var matchingMemberInfo = memberInfo
            .FirstOrDefault(x => x.GetCustomAttribute<DescriptionAttribute>()?.Description == @string);
        return matchingMemberInfo == null ? default : (T)Enum.Parse(enumType, matchingMemberInfo.Name);
    }
}