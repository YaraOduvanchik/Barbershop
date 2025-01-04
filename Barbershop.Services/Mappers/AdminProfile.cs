using AutoMapper;
using Barbershop.Contracts.Commands;
using Barbershop.Contracts.Models;
using Barbershop.Domain.Models;

namespace Barbershop.Services.Mappers;

public class AdminProfile : Profile
{
    public AdminProfile()
    {
        // DL => BL
        CreateMap<User, AdminDto>();

        CreateMap<Admin, AdminDto>()
            .IncludeMembers(x => x.User);

        // BL => DL
        CreateMap<AdminDto, UpsertAdminCommand>()
            .ForMember(dest => dest.Password,
                opt => opt.MapFrom((src, dest, _, context) => context.Items[nameof(UpsertAdminCommand.Password)]));

        CreateMap<UpsertAdminCommand, User>();
        CreateMap<UpsertAdminCommand, Admin>()
            .ForMember(dest => dest.PasswordHash, opt => opt.MapFrom(src => src.Password))
            .ForMember(dest => dest.User, opt => opt.MapFrom(src => src));
    }
}
