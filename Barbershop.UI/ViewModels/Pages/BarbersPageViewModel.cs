using AutoMapper;
using Barbershop.Contracts.Commands;
using Barbershop.Contracts.Models;
using Barbershop.Services.Services;
using Barbershop.UI.Services;
using Barbershop.UI.ViewModels.Base;
using Barbershop.UI.ViewModels.Pages.Edit;
using Barbershop.UI.Views.Pages.Edit;
using HandyControl.Controls;

namespace Barbershop.UI.ViewModels.Pages;

public class BarbersPageViewModel : BaseItemsViewModel<BarberDto>
{
    private readonly BarberService _barberService;
    private readonly IMapper _mapper;
    private readonly IWindowDialogService _dialogService;

    public BarbersPageViewModel(
        BarberService barberService,
        IMapper mapper,
        IWindowDialogService dialogService)
    {
        _barberService = barberService;
        _mapper = mapper;
        _dialogService = dialogService;
    }

    public override async Task CreateItem()
    {
        var vm = new EditBarberViewModel(_dialogService);

        if (_dialogService.ShowDialog(typeof(EditBarberPage), vm))
        {
            var barber = _mapper.Map<BarberDto, UpsertBarberCommand>(vm.Item,
                opt => opt.Items[nameof(UpsertBarberCommand.Password)] = (string)vm.Args.Password!);

            await _barberService.Create(barber);
            await LoadItems();
        }
    }

    public override async Task EditItem()
    {
        var currentBarber = await _barberService.GetById(SelectedItem.Id);
        var vm = new EditBarberViewModel(currentBarber, _dialogService);

        if (_dialogService.ShowDialog(typeof(EditBarberPage), vm))
        {
            var barber = _mapper.Map<BarberDto, UpsertBarberCommand>(vm.Item,
                opt => opt.Items[nameof(UpsertAdminCommand.Password)] = (string)vm.Args.Password!);

            await _barberService.Update(barber);
            await LoadItems();
        }
    }

    public override Task<IReadOnlyList<BarberDto>> GetItems()
        => _barberService.GetAll();

    public override IReadOnlyList<string> GetItemSearchProperties(BarberDto item)
        => new List<string>
        {
            item.LastName!,
            item.FirstName,
            item.Email!,
            item.PhoneNumber!,
            item.SkillLevel.ToString()!,
            $"{item.LastName} {item.FirstName} {item.Surname}"
        };

    public override async Task RemoveItem()
    {
        if (SelectedItem.Id == App.CurrentUser?.Id)
        {
            MessageBox.Warning($"Невозможно удалить текущего пользователя {App.CurrentUser.Login}");
            return;
        }

        await _barberService.RemoveById(SelectedItem.Id);
        await LoadItems();
    }
}
