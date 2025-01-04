namespace Barbershop.Domain.Models;

public class Order : Entity
{
    public OrderStatus OrderStatus { get; set; }
    public DateTime CreatedOn { get; set; }
    public DateTime? CompletedOn { get; set; }
    public int BarbersGain { get; set; }

    public int? BarberId { get; set; }
    public virtual Barber? Barber { get; set; }

    public int ClientId { get; set; }
    public virtual Client Client { get; set; }

    public virtual ICollection<Product> Products { get; set; }
    public virtual ICollection<ServiceSkillLevel> ServiceSkillLevels { get; set; }

    public Order()
    {
        Products = new HashSet<Product>();
        ServiceSkillLevels = new HashSet<ServiceSkillLevel>();
    }
}