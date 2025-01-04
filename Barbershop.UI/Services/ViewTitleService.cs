using Barbershop.UI.ViewModels;
using Barbershop.UI.ViewModels.Base;

namespace Barbershop.UI.Services;

/// <summary>
/// Генерация заголовка окна по его типу.
/// </summary>
internal static class ViewTitleService
{
    private static Dictionary<Type, string> _titles;

    static ViewTitleService()
    {
        _titles = new Dictionary<Type, string>()
        {
            { typeof(AuthViewModel), "Авторизация" },
            { typeof(MainViewModel), "Терминал администратора" }
        };
    }

    public static string Get(this BaseViewModel baseViewModel)
    {
        if (_titles.TryGetValue(baseViewModel.GetType(), out var prefix))
        {
            return $"Barbershop | {prefix}";
        }

        return string.Empty;
    }

    public static string Get<T>()
    {
        if (_titles.TryGetValue(typeof(T), out var prefix))
        {
            return $"Barbershop | {prefix}";
        }

        return string.Empty;
    }
}
