using Barbershop.Contracts.Models;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace Barbershop.UI.Converters;

public sealed class ServiceDtoToServiceConverter : MarkupExtension, IMultiValueConverter
{
    public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    {
        if (values.Length == 2 && values.All(x => x != null))
        {
            var service = values[0] as ServiceDto;
            var selectedBarber = values[1] as BarberDto;

            return MapService(service, selectedBarber.SkillLevel);
        }

        return default!;
    }

    public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }

    public static ServiceSkillLevelDto MapService(ServiceDto service, BarberSkillLevel skillLevel)
        => skillLevel switch
        {
            BarberSkillLevel.Junior => service.JuniorSkill,
            BarberSkillLevel.Middle => service.MiddleSkill,
            BarberSkillLevel.Senior => service.SeniorSkill,
        };

    public override object ProvideValue(IServiceProvider serviceProvider)
            => this;
}
