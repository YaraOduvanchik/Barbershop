using AutoMapper;
using Barbershop.Contracts.Models;
using Barbershop.Domain.Models;
using Barbershop.Domain.Repositories;
using Barbershop.Services.Abstractions;
using Barbershop.Services.Abstractions.Exceptions;
using Barbershop.Services.Helpers;

namespace Barbershop.Services.Services;

public class AuthService : IAuthService
{
    private readonly IBaseRepository<Admin> _adminRepository;
    private readonly IBaseRepository<Barber> _barberRepository;
    private readonly IMapper _mapper;

    public AuthService(
        IBaseRepository<Admin> adminRepository,
        IBaseRepository<Barber> barberRepository,
        IMapper mapper)
    {
        _adminRepository = adminRepository ?? throw new ArgumentNullException(nameof(adminRepository));
        _barberRepository = barberRepository ?? throw new ArgumentNullException(nameof(barberRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<AuthorizedUserDto> Login(string username, string password, bool isAdmin)
    {
        ArgumentNullException.ThrowIfNull(username);
        ArgumentNullException.ThrowIfNull(password);

        var passwordHash = HashService.Compute(password);

        var user = await GetUser(username, passwordHash, isAdmin);

        if (user == null)
            throw new UserNotFoundException();

        return user;
    }

    private async Task<AuthorizedUserDto> GetUser(string username, string password, bool isAdmin)
    {
        if (isAdmin)
        {
            var admin = await _adminRepository.FindSingle(x => x.Login == username && x.PasswordHash == password);
            return _mapper.Map<Admin, AuthorizedUserDto>(admin);
        }

        var barber = await _barberRepository.FindSingle(x => x.Login == username && x.PasswordHash == password);
        return _mapper.Map<Barber, AuthorizedUserDto>(barber);
    }
}