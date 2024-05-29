using System.Globalization;

namespace MauiApp1.helpers;

public class MultipleCommandParameterConverter : IMultiValueConverter
{
    public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    {
        if (values.Length == 2 && values[0] is int firstValue && values[1] is int secondValue)
        {
            return new Tuple<int, int>(firstValue, secondValue);
        }
        return null;
    }

    public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}