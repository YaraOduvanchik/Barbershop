namespace Barbershop.Domain.Models;

public class Admin : Entity
{
    public string Login { get; set; }
    public string PasswordHash { get; set; }

    public virtual User User { get; set; }
}