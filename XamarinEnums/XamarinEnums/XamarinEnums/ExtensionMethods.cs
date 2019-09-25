namespace XamarinEnums
{
    using System;
    using System.ComponentModel;

    static class ExtensionMethods
    {
        public static string ToDescription(this Enum en)
        {
            var type = en.GetType();

            var memInfo = type.GetMember(en.ToString());

            if (memInfo.Length <= 0)
                return en.ToString();

            var attributes = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);

            return attributes.Length > 0 ? ((DescriptionAttribute)attributes[0]).Description : en.ToString();
        }

        public static T ToEnum<T>(this string value, T defaultValue = default) where T : struct
        {
            if (string.IsNullOrEmpty(value))
                return defaultValue; 
            return Enum.TryParse<T>(value, true, out var result) ? result : defaultValue;
        }
    }
}
