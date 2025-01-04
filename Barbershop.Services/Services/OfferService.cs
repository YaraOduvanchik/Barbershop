using AutoMapper;
using Barbershop.Contracts.Commands;
using Barbershop.Contracts.Models;
using Barbershop.Domain.Models;
using Barbershop.Domain.Repositories;

namespace Barbershop.Services.Services;

public sealed class OfferService : EntityService<ServiceDto, Service, UpsertServiceCommand>
{
    private readonly IBaseRepository<ServiceSkillLevel> _serviceSkillLevelRepository;

    public OfferService(
        IBaseRepository<ServiceSkillLevel> serviceSkillLevelRepository,
        IBaseRepository<Service> repository,
        IMapper mapper)
        : base(repository, mapper)
    {
        _serviceSkillLevelRepository = serviceSkillLevelRepository ?? throw new ArgumentNullException(nameof(serviceSkillLevelRepository));
    }

    public override async Task Update(UpsertServiceCommand command)
    {
        //TODO: Добавить проверку, что такой услуги нет

        var storedService = await _entityRepository.GetById(command.Id, x => x.ServiceSkillLevels);
        await SyncServiceSkillLevel(storedService.ServiceSkillLevels, SkillLevel.Junior, command.JuniorSkill);
        await SyncServiceSkillLevel(storedService.ServiceSkillLevels, SkillLevel.Middle, command.MiddleSkill);
        await SyncServiceSkillLevel(storedService.ServiceSkillLevels, SkillLevel.Senior, command.SeniorSkill);

        var service = _mapper.Map<Service>(command);

        await _entityRepository.Update(service);
    }

    public override async Task<IReadOnlyList<ServiceDto>> GetAll()
    {
        var services = await _entityRepository.GetAll(x => x.ServiceSkillLevels);

        return _mapper.Map<IReadOnlyList<ServiceDto>>(services);
    }

    public override async Task<ServiceDto> GetById(int id)
    {
        var service = await _entityRepository.GetById(id, x => x.ServiceSkillLevels);

        return _mapper.Map<ServiceDto>(service);
    }

    private async Task SyncServiceSkillLevel(ICollection<ServiceSkillLevel> skillLevels, SkillLevel skillLevel, ServiceSkillLevelDto? serviceSkillLevelDto)
    {
        var storedSkillLevel = skillLevels.FirstOrDefault(x => x.SkillLevel == skillLevel);

        if (storedSkillLevel != null && serviceSkillLevelDto == null)
        {
            await _serviceSkillLevelRepository.Remove(storedSkillLevel.Id);
        }
    }
}