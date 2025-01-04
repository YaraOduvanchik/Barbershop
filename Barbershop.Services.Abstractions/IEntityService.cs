using Barbershop.Contracts.Commands;
using Barbershop.Contracts.Models;
using Barbershop.Domain.Models;

namespace Barbershop.Services.Abstractions;

/// <summary>
/// Интерфейс для управления сущностями с UI.
/// </summary>
/// <typeparam name="TEntityDto">Сущность для управления.</typeparam>
/// <typeparam name="TCommand">Команды для управления сущностью.</typeparam>

public interface IEntityService<TEntityDto, TEntity, TCommand>
    where TEntityDto : EntityDto
    where TEntity : Entity
    where TCommand : IdentifiedCommand
{
    /// <summary>
    /// Создать сущность типа <typeparamref name="TEntityDto"/>.
    /// </summary>
    /// <param name="command">Описание сущности типа <typeparamref name="TCommand"/>.</param>        
    Task Create(TCommand command);

    /// <summary>
    /// Получить все сущности типа <typeparamref name="TEntityDto"/>.
    /// </summary>
    /// <returns>Список сущностей.</returns>
    Task<IReadOnlyList<TEntityDto>> GetAll();

    /// <summary>
    /// Изменить сущность типа <typeparamref name="TEntityDto"/>.
    /// </summary>
    /// <param name="command">Описание сущности типа <typeparamref name="TCommand"/>.</param>  
    /// <returns>Список сущностей.</returns>
    Task Update(TCommand command);

    /// <summary>
    /// Получить сущность по Id.
    /// </summary>
    /// <param name="id">Id сущности.</param>
    /// <returns>Сущность типа <typeparamref name="TEntityDto"/>.</returns>
    Task<TEntityDto> GetById(int id);

    /// <summary>
    /// Удалить сущность <typeparamref name="TEntityDto"/> по Id.
    /// </summary>
    /// <param name="id">Id сущности.</param>
    Task RemoveById(int id);
}
