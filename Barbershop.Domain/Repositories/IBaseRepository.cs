using Barbershop.Domain.Models;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Barbershop.Domain.Repositories;

/// <summary>
/// Базовый класс репозитория для управления сущностью <typeparamref name="T"/>.
/// </summary>
/// <typeparam name="T">Сущность базы данных.</typeparam>
public interface IBaseRepository<T> where T : Entity, new()
{
    /// <summary>
    /// Создать сущность.
    /// </summary>
    /// <param name="entity">Сущность.</param>
    Task Add(T entity);

    /// <summary>
    /// Удалить сущность по Id.
    /// </summary>
    /// <param name="id">Id сущности.</param>
    /// <returns></returns>
    /// <exception cref="EntityNotFoundException{T}">Не удалось найти сущность.</exception>
    Task Remove(int id);

    /// <summary>
    /// Обновить сущность.
    /// </summary>
    /// <param name="entity">Обновленная сущность.</param>
    Task Update(T entity);

    /// <summary>
    /// Получить все сущности.
    /// </summary>
    /// <param name="including">Список включений сущностей.</param>
    /// <returns>Список сущностей.</returns>
    Task<List<T>> GetAll(params Expression<Func<T, object>>[] including);

    /// <summary>
    /// Получить все сущности.
    /// </summary>
    /// <param name="including">Список включений сущностей.</param>
    /// <returns>Список сущностей.</returns>
    Task<List<T>> GetAll(Func<IQueryable<T>, IIncludableQueryable<T, object>> thenInclude = null);

    /// <summary>
    /// Найти сущности по условию.
    /// </summary>
    /// <param name="predicate">Условие выборки.</param>
    /// <param name="including">Список включений сущностей.</param>
    /// <returns>Отфильтрованные сущности.</returns>
    public Task<IReadOnlyList<T>> FindAll(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] including);

    /// <summary>
    /// Найти сущность по условию.
    /// </summary>
    /// <param name="predicate">Условие выборки.</param>
    /// <param name="including">Список включений сущностей.</param>
    /// <returns>Сущность, если найдена.</returns>
    public Task<T?> FindSingle(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] including);

    /// <summary>
    /// Получить сущность по Id
    /// </summary>
    /// <param name="id">Id сущности.</param>
    /// <param name="including">Список включений сущностей.</param>
    /// <returns>Сущность.</returns>
    /// <exception cref="EntityNotFoundException{T}">Не удалось найти сущность.</exception>
    Task<T> GetById(int id, params Expression<Func<T, object>>[] including);

    /// <summary>
    /// Получить сущность по Id
    /// </summary>
    /// <param name="thenInclude">Список включений сущностей.</param>
    /// <returns>Список сущностей.</returns>
    Task<T> GetById(int id, Func<IQueryable<T>, IIncludableQueryable<T, object>> thenInclude = null);

    /// <summary>
    /// Посчитать количество сущностей типа <typeparamref name="T"/>.
    /// </summary>
    /// <returns>Количество сущностей.</returns>
    public Task<int> Count();
}
