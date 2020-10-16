using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace MegaCasting.WPF.Converter
{
    class ObjectToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Visibility result = Visibility.Collapsed;

            if (((value != null) && parameter is Type && ((Type)parameter).IsAssignableFrom(value.GetType())) || (value != null && parameter == null))
            {
                if (!(value is string) || !string.IsNullOrWhiteSpace((string)value))
                {
                    result = Visibility.Visible;
                }
            }

            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
