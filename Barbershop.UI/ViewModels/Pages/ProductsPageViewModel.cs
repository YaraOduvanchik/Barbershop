using AutoMapper;
using Barbershop.Contracts.Commands;
using Barbershop.Contracts.Models;
using Barbershop.Services.Services;
using Barbershop.UI.Services;
using Barbershop.UI.ViewModels.Base;
using Barbershop.UI.ViewModels.Pages.Edit;
using Barbershop.UI.Views.Pages.Edit;

namespace Barbershop.UI.ViewModels.Pages;

public class ProductsPageViewModel : BaseItemsViewModel<ProductDto>
{
    private readonly ProductService _productService;
    private readonly IMapper _mapper;
    private readonly IWindowDialogService _dialogService;

    public ProductsPageViewModel(
        ProductService productService,
        IMapper mapper,
        IWindowDialogService dialogService)
    {
        _productService = productService ?? throw new ArgumentNullException(nameof(productService));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _dialogService = dialogService ?? throw new ArgumentNullException(nameof(dialogService));
    }

    public override async Task CreateItem()
    {
        var vm = new EditProductViewModel();

        if (_dialogService.ShowDialog(typeof(EditProductPage), vm))
        {
            var command = _mapper.Map<UpsertProductCommand>(vm.Item);
            await _productService.Create(command);
            await LoadItems();
        }
    }

    public override async Task EditItem()
    {
        var currentProduct = await _productService.GetById(SelectedItem.Id);
        var vm = new EditProductViewModel(currentProduct);

        if (_dialogService.ShowDialog(typeof(EditProductPage), vm))
        {
            var command = _mapper.Map<UpsertProductCommand>(vm.Item);
            await _productService.Update(command);
            await LoadItems();
        }
    }

    public override async Task RemoveItem()
    {
        await _productService.RemoveById(SelectedItem.Id);
        await LoadItems();
    }

    public override Task<IReadOnlyList<ProductDto>> GetItems()
        => _productService.GetAll();

    public override IReadOnlyList<string> GetItemSearchProperties(ProductDto item)
        => new List<string>
        {
            item.Name,
            item.Cost.ToString()
        };
}
