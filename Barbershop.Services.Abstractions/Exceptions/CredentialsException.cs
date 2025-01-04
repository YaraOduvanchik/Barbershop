namespace Barbershop.Services.Abstractions.Exceptions;

public class CredentialsException : Exception
{
    public CredentialsException()
        : base("Неверный логин или пароль.")
    {
    }
}