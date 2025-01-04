namespace Barbershop.Contracts.Models;

public class BarberDto : UserDto
{
    public string Login { get; set; }
    public string PasswordHash { get; set; }

    public BarberSkillLevel SkillLevel { get; set; }

    public virtual ICollection<OrderDto> Orders { get; set; }

    public override string ToString()
        => string.Join(' ', LastName, FirstName, Surname);

    public bool IsSelected
    {
        get => GetValue<bool>(nameof(IsSelected));
        set => SetValue(value, nameof(IsSelected));
    }
}