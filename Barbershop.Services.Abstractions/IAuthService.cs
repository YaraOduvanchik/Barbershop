using Barbershop.Contracts.Models;

namespace Barbershop.Services.Abstractions;

/// <summary>
/// Сервис для авторизации пользователя
/// </summary>
public interface IAuthService
{
    /// <summary>
    /// Авторизировать пользователя.
    /// </summary>
    /// <param name="username">Логин.</param>
    /// <param name="password">Пароль в явном виде.</param>
    /// <param name="isAdmin">Признак администратора.</param>
    /// <returns></returns>
    Task<AuthorizedUserDto> Login(string username, string password, bool isAdmin);
}