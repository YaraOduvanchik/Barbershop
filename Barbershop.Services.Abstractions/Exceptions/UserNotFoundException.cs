namespace Barbershop.Services.Abstractions.Exceptions;

public class UserNotFoundException : Exception
{
    public UserNotFoundException()
        : base("Пользователь с таким логином и паролем не существует.")
    {
    }
}