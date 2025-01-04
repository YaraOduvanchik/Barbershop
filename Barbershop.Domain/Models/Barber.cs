namespace Barbershop.Domain.Models;

public class Barber : Entity
{
    public string Login { get; set; }
    public string PasswordHash { get; set; }
    public SkillLevel SkillLevel { get; set; }

    public virtual ICollection<Order> Orders { get; set; }

    public virtual User User { get; set; }

    public Barber()
    {
        Orders = new HashSet<Order>();
    }
}
