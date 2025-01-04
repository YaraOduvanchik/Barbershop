using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace Barbershop.UI.Converters;

/// <summary>
/// Преобразование числа в строку с валютой.
/// </summary>
public sealed class DecimalToCurrencyConverter : MarkupExtension, IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is decimal cost)
        {
            return $"{cost:C2}";
        }

        return string.Empty;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }

    public override object ProvideValue(IServiceProvider serviceProvider)
        => this;
}
