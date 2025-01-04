using AutoMapper;
using Barbershop.Contracts.Commands;
using Barbershop.Contracts.Models;
using Barbershop.Domain.Models;
using Barbershop.Domain.Repositories;
using Barbershop.Services.Helpers;
using Microsoft.EntityFrameworkCore;

namespace Barbershop.Services.Services;

public class BarberService : EntityService<BarberDto, Barber, UpsertBarberCommand>
{
    public BarberService(IBaseRepository<Barber> barberRepository, IMapper mapper)
        : base(barberRepository, mapper)
    {
    }

    public override async Task Create(UpsertBarberCommand command)
    {
        command.Password = HashService.Compute(command.Password);
        var barber = _mapper.Map<Barber>(command);

        await _entityRepository.Add(barber);
    }

    public override async Task Update(UpsertBarberCommand command)
    {
        var barber = _mapper.Map<Barber>(command);

        if (string.IsNullOrEmpty(barber.PasswordHash))
        {
            barber.PasswordHash = (await _entityRepository.GetById(barber.Id)).PasswordHash;
        }
        else
        {
            barber.PasswordHash = HashService.Compute(command.Password);
        }

        await _entityRepository.Update(barber);
    }

    public override async Task<IReadOnlyList<BarberDto>> GetAll()
    {
        var barbers = await _entityRepository.GetAll(x => x.User);

        return _mapper.Map<IReadOnlyList<BarberDto>>(barbers);
    }

    public override async Task<BarberDto> GetById(int id)
    {
        var barber = await _entityRepository.GetById(id,
            x => x.Include(x => x.User)
                .Include(x => x.Orders)
                    .ThenInclude(x => x.Products)
                .Include(x => x.Orders)
                    .ThenInclude(x => x.ServiceSkillLevels));

        return _mapper.Map<BarberDto>(barber);
    }
}