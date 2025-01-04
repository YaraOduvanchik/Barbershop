namespace Barbershop.Domain.Models;

public class Product : Entity
{
    public string Name { get; set; }
    public decimal Cost { get; set; }

    public virtual ICollection<Order> Orders { get; set; }

    public Product()
    {
        Orders = new HashSet<Order>();
    }
}