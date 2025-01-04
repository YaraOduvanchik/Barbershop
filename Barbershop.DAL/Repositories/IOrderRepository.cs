using Barbershop.Domain.Models;

namespace Barbershop.DAL.Repositories;

public interface IOrderRepository
{
    Task CreateOrder(Order order);

    Task UpdateProducts(int orderId, IReadOnlyList<int> productsIds);
}