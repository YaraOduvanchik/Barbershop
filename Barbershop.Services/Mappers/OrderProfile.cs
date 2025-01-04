using AutoMapper;
using AutoMapper.Extensions.EnumMapping;
using Barbershop.Contracts.Models;
using Barbershop.Domain.Models;

namespace Barbershop.Services.Mappers;

public class OrderProfile : Profile
{
    public OrderProfile()
    {
        CreateMap<Order, OrderDto>()
            .ForMember(dest => dest.BeginDateTime, opt => opt.MapFrom(src => src.CreatedOn))
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.OrderStatus))
            .ForMember(dest => dest.Services, opt => opt.MapFrom(src => src.ServiceSkillLevels));

        CreateMap<ServiceSkillLevel, OrderServiceDto>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Service.Name));

        CreateMap<OrderStatus, OrderStatusDto>()
            .ConvertUsingEnumMapping()
            .ReverseMap();
    }
}
