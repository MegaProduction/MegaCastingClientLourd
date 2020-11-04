using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace MegaCasting.WPF.Converter
{
    class BoolToVisibility : IValueConverter, IMultiValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Visibility result = Visibility.Collapsed;
            if (parameter is string && parameter.ToString() == "!" && value is bool && !((bool)value))
            {
                result = Visibility.Visible;
            }
            else if (string.IsNullOrWhiteSpace(parameter as string) && value is bool && ((bool)value))
            {
                result = Visibility.Visible;
            }
            return result;
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            bool value = false;
            foreach (bool item in values.OfType<bool>())
            {
                value = value && item;
            }
            return Convert(value, targetType, parameter, culture);
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
