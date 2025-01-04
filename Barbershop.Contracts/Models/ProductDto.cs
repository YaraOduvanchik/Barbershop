namespace Barbershop.Contracts.Models;

public class ProductDto : EntityDto
{
    public string Name { get; set; }
    public decimal Cost { get; set; }
    public int SalesCount { get; set; }

    public override string ToString()
    {
        return $"{Name} {Cost:C2}";
    }
}