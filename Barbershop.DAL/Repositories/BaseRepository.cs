using Barbershop.DAL.Context;
using Barbershop.DAL.Exceptions;
using Barbershop.Domain.Models;
using Barbershop.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Barbershop.DAL.Repositories;

/// <summary>
/// Базовый класс репозитория для управления сущностью <typeparamref name="T"/>.
/// </summary>
/// <typeparam name="T">Сущность базы данных.</typeparam>
internal class BaseRepository<T> : IBaseRepository<T> where T : Entity, new()
{
    protected readonly BarbershopContextFactory _contextFactory;

    public BaseRepository(BarbershopContextFactory contextFactory)
    {
        _contextFactory = contextFactory ?? throw new ArgumentNullException(nameof(contextFactory));
    }

    public async Task Add(T entity)
    {
        using var context = _contextFactory.CreateContext();

        context.Add(entity);

        await context.SaveChangesAsync();
    }

    public async Task Remove(int id)
    {
        using var context = _contextFactory.CreateContext();

        var entity = await context.Set<T>().FindAsync(id)
            ?? throw new EntityNotFoundException<T>(id);

        context.Set<T>().Remove(entity);

        await context.SaveChangesAsync();
    }

    public async Task Update(T item)
    {
        using var context = _contextFactory.CreateContext();

        await GetById(item.Id);

        context.Set<T>().Update(item);
        context.Entry(item).State = EntityState.Modified;

        await context.SaveChangesAsync();
    }

    public async Task<List<T>> GetAll(params Expression<Func<T, object>>[] including)
    {
        using var context = _contextFactory.CreateContext();

        var query = context.Set<T>().AsQueryable();

        foreach (var include in including)
        {
            query = query.Include(include);
        }

        return await query.OrderBy(x => x.Id).ToListAsync();
    }

    public async Task<List<T>> GetAll(Func<IQueryable<T>, IIncludableQueryable<T, object>> thenInclude)
    {
        using var context = _contextFactory.CreateContext();

        var query = context.Set<T>().AsQueryable();

        if (thenInclude != null)
            query = thenInclude.Invoke(query);

        return await query.OrderBy(x => x.Id).ToListAsync();
    }

    public async Task<IReadOnlyList<T>> FindAll(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] including)
    {
        using var context = _contextFactory.CreateContext();

        var query = context.Set<T>().Where(predicate);

        foreach (var include in including)
        {
            query = query.Include(include);
        }

        return await query.OrderBy(x => x.Id).ToListAsync();
    }

    public async Task<T?> FindSingle(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] including)
    {
        using var context = _contextFactory.CreateContext();

        var query = context.Set<T>().AsQueryable();

        foreach (var include in including)
        {
            query = query.Include(include);
        }

        var entity = await query
            .FirstOrDefaultAsync(predicate);

        return entity;
    }

    public async Task<T> GetById(int id, params Expression<Func<T, object>>[] including)
    {
        using var context = _contextFactory.CreateContext();

        var query = context.Set<T>().AsQueryable();

        foreach (var include in including)
        {
            query = query.Include(include);
        }

        var entity = await query.FirstOrDefaultAsync(x => x.Id == id)
            ?? throw new EntityNotFoundException<T>(id);

        return entity;
    }

    public async Task<int> Count()
    {
        using var context = _contextFactory.CreateContext();

        if (context.Set<T>().TryGetNonEnumeratedCount(out var count))
            return count;

        return await context.Set<T>().CountAsync();
    }

    public async Task<T> GetById(int id, Func<IQueryable<T>, IIncludableQueryable<T, object>> thenInclude = null)
    {
        using var context = _contextFactory.CreateContext();

        var query = context.Set<T>().AsQueryable();

        if (thenInclude != null)
            query = thenInclude.Invoke(query);

        var entity = await query.FirstOrDefaultAsync(x => x.Id == id)
            ?? throw new EntityNotFoundException<T>(id);

        return entity;
    }
}
