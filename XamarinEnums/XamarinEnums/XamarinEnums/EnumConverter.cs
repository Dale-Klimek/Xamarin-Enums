using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinEnums
{
    using System.Globalization;
    using System.Linq;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    class EnumConverter : IValueConverter, IMarkupExtension
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(!value.GetType().IsEnum)
                throw new ArgumentException($"{nameof(value.GetType)} must be an enum type");
            
            var result = Enum.Parse(value.GetType(), value.ToString()) as Enum;
            return result.ToDescription();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return null;
            if(!targetType.IsEnum)
                throw new ArgumentException($"{nameof(value.GetType)} must be an enum type");

            return Enum.GetValues(targetType).Cast<Enum>().FirstOrDefault(name => string.CompareOrdinal(name.ToDescription(), value.ToString()) == 0);
        }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
    }
}
