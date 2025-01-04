namespace Barbershop.Contracts.Models;

public class OrderDto : EntityDto
{
    public OrderStatusDto Status { get; set; }

    public int BarbersGain { get; set; }

    public BarberDto Barber { get; set; }
    public ClientDto Client { get; set; }

    public List<OrderServiceDto> Services { get; set; }
    public List<ProductDto> Products { get; set; }

    public DateTime BeginDateTime { get; set; }

    public DateTime EndDateTime
        => BeginDateTime.AddMinutes(Services.Sum(x => x.MinutesDuration));

    public decimal PureCost => (TotalServicesPrice * BarbersGain / 100) + (Products.Sum(x => x.Cost) * 15 / 100);

    public decimal TotalServicesPrice => Services.Sum(x => x.Cost);

    public decimal TotalPrice =>
        Services.Sum(x => x.Cost) + Products.Sum(x => x.Cost);

    public int TotalMinutes =>
        Services.Sum(x => x.MinutesDuration);
}
