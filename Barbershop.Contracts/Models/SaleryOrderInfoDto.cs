namespace Barbershop.Contracts.Models;

public sealed class SaleryOrderInfoDto : EntityDto
{
    public DateTime BeginDateTime { get; set; }
    public ClientDto Client { get; set; }

}
