using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace MegaCasting.WPF.Converter
{
    class BoolToEnabled : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            bool returnValid = true;
            foreach (object value in values)
            {
                if ((value is bool) && (bool)value == false && string.IsNullOrWhiteSpace(value.ToString()))
                {
                    returnValid = false;
                }
            }
            return returnValid;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
