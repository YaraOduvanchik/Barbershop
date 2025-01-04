using System.ComponentModel;

namespace Barbershop.Contracts.Models;

public enum BarberSkillLevel
{
    [Description("Младший мастер")]
    Junior,

    [Description("Мастер")]
    Middle,

    [Description("Старший мастер")]
    Senior
}