using Barbershop.UI.ViewModels;
using Barbershop.UI.Views.Pages;

namespace Barbershop.UI.Services;

public static class ViewItemsManager
{
    public static IReadOnlyList<ItemModel> GetItems()
    {
        if (App.CurrentUser.IsAdmin)
        {
            return new List<ItemModel>()
            {
                new("Главная", "HomeImage", typeof(MainPage)),
                new("Администраторы", "AdminImage", typeof(AdminsPage)),
                new("Товары", "ProductImage", typeof(ProductsPage)),
                new("Барберы", "BarberImage", typeof(BarbersPage)),
                new("Клиенты", "ClientImage", typeof(ClientsPage)),
                new("Услуги", "ServiceImage", typeof(ServicesPage)),
                new("Заказы", "SalaryImage", typeof(OrdersPage)),
                new("Зарплата", "MoneyImage", typeof(SalaryPageAdmin))
            };
        }

        return new List<ItemModel>()
        {
            new("Главная", "HomeImage", typeof(MainPage)),
            new("Моя страница", "BarberImage", typeof(CurrentBarberPage)),
            new("Заказы", "SalaryImage", typeof(OrdersPage)),
            new("Зарплата", "MoneyImage", typeof(SalaryPage))
        };
    }
}