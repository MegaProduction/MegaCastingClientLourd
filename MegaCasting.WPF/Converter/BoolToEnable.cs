using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace MegaCasting.WPF.Converter
{
    class BoolToEnable : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            bool isEnable = true;
            foreach (object value in values)
            {
                if (string.IsNullOrWhiteSpace(value.ToString()))
                {
                    isEnable = false;
                }
            }
            return isEnable;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

    }
}


