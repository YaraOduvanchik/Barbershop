using AutoMapper;
using Barbershop.Contracts.Commands;
using Barbershop.Contracts.Models;
using Barbershop.Domain.Models;

namespace Barbershop.Services.Mappers;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        // DL => BL
        CreateMap<Product, ProductDto>()
            .ForMember(dest => dest.SalesCount,
                opt => opt.MapFrom(src => src.Orders.Where(x => x.OrderStatus == OrderStatus.Done).Count()));

        // BL => DL
        CreateMap<ProductDto, UpsertProductCommand>();

        CreateMap<UpsertProductCommand, Product>();
    }
}