using Barbershop.Domain.Models;

namespace Barbershop.DAL.Exceptions;

public class EntityNotFoundException<T> : Exception where T : Entity
{
    public EntityNotFoundException(int id)
        : base($"{nameof(T)} with Id {id} not found.")
    {
    }
}