namespace Barbershop.Services.Abstractions.Exceptions;

public class RemoveAdminException : Exception
{
    public RemoveAdminException()
        : base("Невозможно удалить единственного администратора.")
    {
    }
}