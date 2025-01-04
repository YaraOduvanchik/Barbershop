namespace Barbershop.Contracts.Commands;

public class UpsertClientCommand : IdentifiedCommand
{
    public string? LastName { get; set; }
    public string FirstName { get; set; }
    public string? Surname { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public byte[]? Photo { get; set; }
    public DateTime? Birthday { get; set; }

    public string Notes { get; set; }
}