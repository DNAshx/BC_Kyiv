using System;
using System.Globalization;
using System.Windows.Data;

namespace BCKyivApp.WPF.Converters
{
    public class SelectionToOpacityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool)
            {
                if ((bool)value)
                {
                    return 1.0;
                }
            }
            return 0.3;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}