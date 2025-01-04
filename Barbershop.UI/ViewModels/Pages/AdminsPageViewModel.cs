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

public class AdminsPageViewModel : BaseItemsViewModel<AdminDto>
{
    private readonly AdminService _adminService;
    private readonly IMapper _mapper;
    private readonly IWindowDialogService _dialogService;

    public AdminsPageViewModel(AdminService adminService, IMapper mapper, IWindowDialogService dialogService)
    {
        _adminService = adminService ?? throw new ArgumentNullException(nameof(adminService));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _dialogService = dialogService ?? throw new ArgumentNullException(nameof(dialogService));
    }

    public override Task<IReadOnlyList<AdminDto>> GetItems()
        => _adminService.GetAll();

    public override IReadOnlyList<string> GetItemSearchProperties(AdminDto item)
        => new List<string>
        {
            item.LastName!,
            item.FirstName,
            item.Email!,
            item.PhoneNumber!,
            item.Login,
            $"{item.LastName} {item.FirstName} {item.Surname}"
        };

    public override async Task CreateItem()
    {
        var vm = new EditAdminViewModel(_dialogService);

        if (_dialogService.ShowDialog(typeof(EditAdminPage), vm))
        {
            var admin = _mapper.Map<AdminDto, UpsertAdminCommand>(vm.Item,
                opt => opt.Items[nameof(UpsertAdminCommand.Password)] = (string)vm.Args.Password!);

            await _adminService.Create(admin);
            await LoadItems();
        }
    }

    public override async Task EditItem()
    {
        var currentAdmin = await _adminService.GetById(SelectedItem.Id);
        var vm = new EditAdminViewModel(currentAdmin, _dialogService);

        if (_dialogService.ShowDialog(typeof(EditAdminPage), vm))
        {
            var admin = _mapper.Map<AdminDto, UpsertAdminCommand>(vm.Item,
                opt => opt.Items[nameof(UpsertAdminCommand.Password)] = (string)vm.Args.Password!);

            await _adminService.Update(admin);
            await LoadItems();
        }
    }

    public override async Task RemoveItem()
    {
        if (SelectedItem.Id == App.CurrentUser?.Id)
        {
            MessageBox.Warning($"Невозможно удалить текущего пользователя {App.CurrentUser.Login}");
            return;
        }

        await _adminService.RemoveById(SelectedItem.Id);
        await LoadItems();
    }
}