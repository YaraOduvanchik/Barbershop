namespace Barbershop.Contracts.Commands;

public class UpsertProductCommand : IdentifiedCommand
{
    public string Name { get; set; }
    public decimal Cost { get; set; }
}
