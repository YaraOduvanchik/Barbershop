using Barbershop.Contracts.Models;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace Barbershop.UI.Converters;

public sealed class OrderStatusToEnableConverter : MarkupExtension, IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is OrderStatusDto status)
        {
            return status == OrderStatusDto.Created;
        }

        return false;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }

    public override object ProvideValue(IServiceProvider serviceProvider)
        => this;
}
