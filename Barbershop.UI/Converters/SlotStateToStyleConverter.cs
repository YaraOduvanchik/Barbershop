using Barbershop.UI.ViewModels.Pages.Edit;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;

namespace Barbershop.UI.Converters;

internal class SlotStateToStyleConverter : MarkupExtension, IValueConverter
{
    private static Style _defaultStyle = Application.Current.TryFindResource("RadioButtonIconBaseStyle") as Style;
    private static Style _notAllowedStyle = Application.Current.TryFindResource("RadioButtonSameAsButtonPrimary") as Style;

    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is TimeSlotState state)
        {
            return state switch
            {
                TimeSlotState.NotAllowed => _notAllowedStyle,
                _ => _defaultStyle
            };
        }

        return default!;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }

    public override object ProvideValue(IServiceProvider serviceProvider)
        => this;
}