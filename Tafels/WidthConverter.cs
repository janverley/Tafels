using System;
using System.Globalization;
using System.Windows.Data;

namespace Tafels
{
    public class WidthConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var totalValue = (int)values[0];
            var progressValue = (int)values[1];
            var actualWidthValue = (double)values[2];

            return (double)progressValue / totalValue * actualWidthValue;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new InvalidOperationException();
        }
    }
}