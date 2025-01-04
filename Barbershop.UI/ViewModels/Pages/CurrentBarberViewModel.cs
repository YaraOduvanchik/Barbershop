using Barbershop.Contracts.Models;
using Barbershop.Services.Services;
using Barbershop.UI.ViewModels.Base;
using DevExpress.Mvvm;

namespace Barbershop.UI.ViewModels.Pages;

public class CurrentBarberViewModel : BaseViewModel
{
    private readonly BarberService _barberService;

    public BarberDto CurrentBarber
    {
        get => GetValue<BarberDto>(nameof(CurrentBarber));
        set => SetValue(value, nameof(CurrentBarber));
    }

    public int CompletedOrdersCount => CurrentBarber?.Orders.Count(x => x.Status == OrderStatusDto.Done) ?? 0;
    public int CompletedServicesCount => CurrentBarber?.Orders.Where(x => x.Status == OrderStatusDto.Done).Sum(x => x.Services.Count()) ?? 0;
    public int CompletedProductsCount => CurrentBarber?.Orders.Where(x => x.Status == OrderStatusDto.Done).Sum(x => x.Products.Count()) ?? 0;

    public CurrentBarberViewModel(BarberService barberService)
    {
        _barberService = barberService ?? throw new ArgumentNullException(nameof(barberService));

        LoadViewDataCommand = new AsyncCommand(LoadView);
    }

    public async Task LoadView()
    {
        await Execute(async () =>
        {
            CurrentBarber = await _barberService.GetById(App.CurrentUser.Id);
            RaisePropertiesChanged(nameof(CompletedOrdersCount), nameof(CompletedServicesCount), nameof(CompletedProductsCount));
        });
    }
}
