using Barbershop.Contracts.Models;
using Barbershop.UI.ViewModels.Base;

namespace Barbershop.UI.ViewModels.Pages.Edit;

public class EditProductViewModel : EditViewModel<ProductDto>
{
    public EditProductViewModel(ProductDto itemViewModel)
        : this()
    {
        Item = itemViewModel;
    }

    public EditProductViewModel()
        : base()
    {
        
    }

    public override IReadOnlyList<string> GetErrors()
    {
        var errors = new List<string>();

        if (string.IsNullOrWhiteSpace(Item.Name))
            errors.Add("Введите название товара.");

        return errors;
    }
}
