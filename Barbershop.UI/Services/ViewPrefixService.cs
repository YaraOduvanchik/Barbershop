using Barbershop.Contracts.Models;

namespace Barbershop.UI.Services;

/// <summary>
/// Генерация префикса окона по его типу.
/// </summary>
internal class ViewPrefixService
{
    private static Dictionary<Type, string> _prefixes;

    static ViewPrefixService()
    {
        _prefixes = new Dictionary<Type, string>()
        {
            { typeof(AdminDto), "администратора"},
            { typeof(BarberDto), "барбера"},
            { typeof(ClientDto), "клиента"},
            { typeof(ProductDto), "товара"},
            { typeof(OrderDto), "заказа" }
        };
    }

    public static string Get<T>()
    {
        if (_prefixes.TryGetValue(typeof(T), out var prefix))
        {
            return prefix;
        }

        return string.Empty;
    }
}
