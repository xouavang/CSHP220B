using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Data;

namespace LaptopLoanerApp.Helpers
{
    public class IntToNullableIntConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int val = (int)value;
            return (val == 0) ? string.Empty : val.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string val = value as string;
            return (string.IsNullOrWhiteSpace(val)) ? 0 : int.Parse(val);
        }
    }
}
