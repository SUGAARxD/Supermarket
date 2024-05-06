using System;
using System.Globalization;
using System.Windows.Data;

namespace SupermarketApp.Converters
{
    public class StringToDateConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string dateString)
            {
                if (DateTime.TryParse(dateString, out DateTime dateTime))
                {
                    return dateTime;
                }
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is DateTime dateTime)
            {
                return dateTime.ToShortDateString();
            }
            return string.Empty;
        }
    }
}
