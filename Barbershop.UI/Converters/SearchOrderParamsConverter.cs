using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace Barbershop.UI.Converters;

public sealed class SearchOrderParamsConverter : MarkupExtension, IMultiValueConverter
{
    public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    {
        return values.Clone();
    }

    public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }

    public override object ProvideValue(IServiceProvider serviceProvider)
        => this;
}