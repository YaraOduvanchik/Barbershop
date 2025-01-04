using AutoMapper;
using Barbershop.Contracts.Commands;
using Barbershop.Contracts.Models;
using Barbershop.Domain.Models;
using Barbershop.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Barbershop.Services.Services;

public class ClientService : EntityService<ClientDto, Client, UpsertClientCommand>
{
    public ClientService(IBaseRepository<Client> clientRepo, IMapper mapper)
        : base(clientRepo, mapper)
    {
    }

    public override async Task<IReadOnlyList<ClientDto>> GetAll()
    {
        var clients = await _entityRepository.GetAll(x => x.Include(x => x.User).Include(x => x.Orders));

        return _mapper.Map<IReadOnlyList<ClientDto>>(clients);
    }

    public override async Task<ClientDto> GetById(int id)
    {
        var client = await _entityRepository.GetById(id, x => x.User);

        return _mapper.Map<ClientDto>(client);
    }
}