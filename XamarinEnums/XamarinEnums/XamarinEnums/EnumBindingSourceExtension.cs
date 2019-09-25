namespace XamarinEnums
{
    using System;
    using System.Globalization;
    using System.Linq;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    class EnumBindingSourceExtension : IMarkupExtension, IValueConverter
    {
        public object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!value.GetType().IsEnum)
                throw new ArgumentException($"{nameof(value.GetType)} must be an enum type");
            return Enum.GetValues(value.GetType()).Cast<Enum>().Select(e => e.ToDescription()).ToList();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
