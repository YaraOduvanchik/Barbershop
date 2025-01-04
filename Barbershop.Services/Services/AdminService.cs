using AutoMapper;
using Barbershop.Contracts.Commands;
using Barbershop.Contracts.Models;
using Barbershop.Domain.Models;
using Barbershop.Domain.Repositories;
using Barbershop.Services.Helpers;

namespace Barbershop.Services.Services;

public sealed class AdminService : EntityService<AdminDto, Admin, UpsertAdminCommand>
{
    public AdminService(IBaseRepository<Admin> adminRepository, IMapper mapper)
        : base(adminRepository, mapper)
    {
    }

    public override async Task Create(UpsertAdminCommand command)
    {
        command.Password = HashService.Compute(command.Password);
        var admin = _mapper.Map<Admin>(command);

        await _entityRepository.Add(admin);
    }

    public override async Task Update(UpsertAdminCommand command)
    {
        var admin = _mapper.Map<Admin>(command);

        if (string.IsNullOrEmpty(admin.PasswordHash))
        {
            admin.PasswordHash = (await _entityRepository.GetById(admin.Id)).PasswordHash;
        }
        else
        {
            admin.PasswordHash = HashService.Compute(command.Password);
        }

        await _entityRepository.Update(admin);
    }

    public override async Task<IReadOnlyList<AdminDto>> GetAll()
    {
        var admins = await _entityRepository.GetAll(x => x.User);

        return _mapper.Map<IReadOnlyList<AdminDto>>(admins);
    }

    public override async Task<AdminDto> GetById(int id)
    {
        var admin = await _entityRepository.GetById(id, x => x.User);

        return _mapper.Map<AdminDto>(admin);
    }
}
