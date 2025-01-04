namespace Barbershop.Contracts.Models;

public class ServiceSkillLevelDto : EntityDto
{
    public decimal Cost { get; set; }
    public int MinutesDuration { get; set; }
}
