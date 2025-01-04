namespace Barbershop.Contracts.Models;

public class OrderServiceDto : EntityDto
{
    public string Name { get; set; }
    public BarberSkillLevel SkillLevel { get; set; }
    public int MinutesDuration { get; set; }
    public decimal Cost { get; set; }
}