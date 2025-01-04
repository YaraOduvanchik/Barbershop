using Barbershop.DAL.Context;
using Barbershop.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Barbershop.DAL.Repositories;

internal class OrderRepository : BaseRepository<Order>, IOrderRepository
{
    public OrderRepository(BarbershopContextFactory contextFactory) : base(contextFactory)
    {
    }

    public async Task CreateOrder(Order order)
    {
        using var context = _contextFactory.CreateContext();

        var barber = await context.Barbers.FindAsync(order.BarberId);

        order.BarbersGain = barber.SkillLevel switch
        {
            SkillLevel.Junior => 15,
            SkillLevel.Middle => 25,
            SkillLevel.Senior => 35
        };

        foreach (var service in order.ServiceSkillLevels)
        {
            context.Attach(service).State = EntityState.Unchanged;
        }

        context.Orders.Add(order);
        await context.SaveChangesAsync();
    }

    public async Task UpdateProducts(int orderId, IReadOnlyList<int> productsIds)
    {
        using var context = _contextFactory.CreateContext();

        var order = await context.Orders
            .Include(x => x.Products)
            .FirstAsync(x => x.Id == orderId);

        order.Products.Clear();

        var products = await context.Products
            .Where(x => productsIds.Contains(x.Id))
            .ToListAsync();

        order.Products = products;
        await context.SaveChangesAsync();
    }
}
