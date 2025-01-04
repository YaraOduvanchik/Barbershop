using AutoMapper;
using Barbershop.Contracts.Models;
using Barbershop.Domain.Models;

namespace Barbershop.Services.Mappers;

public class AuthorizedUserProfile : Profile
{
    public AuthorizedUserProfile()
    {
        CreateMap<Admin, AuthorizedUserDto>()
            .ForMember(x => x.IsAdmin, cfg => cfg.MapFrom(x => true));

        CreateMap<Barber, AuthorizedUserDto>();
    }
}
