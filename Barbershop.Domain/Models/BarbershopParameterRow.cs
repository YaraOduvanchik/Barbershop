namespace Barbershop.Domain.Models;

public class BarbershopParameterRow : Entity
{
    public int WorkDayStartsOn { get; set; }
    public int WorkDayEndsOn { get; set; }
    public int PercentFromProductSelling { get; set; }
    public int JuniorServiceSalePercent { get; set; }
    public int MiddleServiceSalePercent { get; set; }
    public int SeniorServiceSalePercent { get; set; }
}