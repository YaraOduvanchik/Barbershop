using AutoMapper;
using Barbershop.Contracts.Commands;
using Barbershop.Contracts.Models;
using Barbershop.Domain.Models;
using Barbershop.Domain.Repositories;

namespace Barbershop.Services.Services;

public sealed class ProductService : EntityService<ProductDto, Product, UpsertProductCommand>
{
    public ProductService(IBaseRepository<Product> repository, IMapper mapper)
        : base(repository, mapper)
    {
    }

    public override async Task<IReadOnlyList<ProductDto>> GetAll()
    {
        var products = await _entityRepository.GetAll(x => x.Orders);

        return _mapper.Map<IReadOnlyList<ProductDto>>(products);
    }
}
