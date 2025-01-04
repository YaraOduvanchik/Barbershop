using AutoMapper;
using Barbershop.Contracts.Commands;
using Barbershop.Contracts.Models;
using Barbershop.Domain.Models;

namespace Barbershop.Services.Mappers;

public class BarberProfile : Profile
{
    public BarberProfile()
    {
        CreateMap<User, BarberDto>();

        CreateMap<Barber, BarberDto>()
            .IncludeMembers(x => x.User);

        CreateMap<BarberDto, UpsertBarberCommand>()
            .ForMember(dest => dest.Password,
                opt => opt.MapFrom((src, dest, _, context) => context.Items[nameof(UpsertBarberCommand.Password)]));

        CreateMap<UpsertBarberCommand, User>();
        CreateMap<UpsertBarberCommand, Barber>()
            .ForMember(dest => dest.PasswordHash, opt => opt.MapFrom(src => src.Password))
            .ForMember(dest => dest.User, opt => opt.MapFrom(src => src));
    }
}
