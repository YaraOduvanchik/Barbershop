using AutoMapper;
using Barbershop.Contracts.Commands;
using Barbershop.Contracts.Models;
using Barbershop.Domain.Models;
using Barbershop.Domain.Repositories;
using Barbershop.Services.Abstractions;

namespace Barbershop.Services.Services;

public class EntityService<TEntityDto, TEntity, TCommand> : IEntityService<TEntityDto, TEntity, TCommand>
    where TEntityDto : EntityDto, new()
    where TEntity : Entity, new()
    where TCommand : IdentifiedCommand, new()
{
    protected readonly IBaseRepository<TEntity> _entityRepository;
    protected readonly IMapper _mapper;

    public EntityService(IBaseRepository<TEntity> repository, IMapper mapper)
    {
        _entityRepository = repository;
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public virtual Task Create(TCommand command)
    {
        var entity = _mapper.Map<TEntity>(command);

        return _entityRepository.Add(entity);
    }

    public virtual async Task<IReadOnlyList<TEntityDto>> GetAll()
    {
        var entites = await _entityRepository.GetAll();

        return _mapper.Map<IReadOnlyList<TEntityDto>>(entites);
    }

    public virtual async Task<TEntityDto> GetById(int id)
    {
        var entity = await _entityRepository.GetById(id);

        return _mapper.Map<TEntityDto>(entity);
    }

    public virtual async Task Update(TCommand command)
    {
        var entity = _mapper.Map<TEntity>(command);

        await _entityRepository.Update(entity);
    }

    public async Task RemoveById(int id)
    {
        await _entityRepository.Remove(id);
    }
}
