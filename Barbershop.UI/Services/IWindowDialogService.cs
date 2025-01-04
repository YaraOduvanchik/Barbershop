using Barbershop.UI.ViewModels.Base;
using Barbershop.UI.ViewModels.Pages.Edit;

namespace Barbershop.UI.Services;

/// <summary>
/// Интерфейс управления диалоговым окном.
/// </summary>
public interface IWindowDialogService
{
    bool ShowDialog(Type controlType, BaseViewModel dataContext);
    bool ShowDialog(CreateOrderViewModel dataContext);
    bool SelectImage(out byte[] imageBytes);
}
