using AutoMapper;
using Barbershop.Contracts.Commands;
using Barbershop.Contracts.Models;
using Barbershop.Services.Services;
using Barbershop.UI.Services;
using Barbershop.UI.ViewModels.Base;
using Barbershop.UI.ViewModels.Pages.Edit;
using Barbershop.UI.Views.Pages.Edit;
using DevExpress.Mvvm;

namespace Barbershop.UI.ViewModels.Pages;

public sealed class ServicesPageViewModel : BaseItemsViewModel<ServiceDto>
{
    private readonly OfferService _offerService;
    private readonly IMapper _mapper;
    private readonly IWindowDialogService _dialogService;

    public ServicesPageViewModel(OfferService offerService, IMapper mapper, IWindowDialogService dialogService)
    {
        _offerService = offerService ?? throw new ArgumentNullException(nameof(offerService));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _dialogService = dialogService ?? throw new ArgumentNullException(nameof(dialogService));

        EditItemCommand = new AsyncCommand<object>(EditItem);
        RemoveItemCommand = new AsyncCommand<object>(RemoveItem);
    }

    public override async Task CreateItem()
    {
        var vm = new EditServiceViewModel();

        if (_dialogService.ShowDialog(typeof(EditServicePage), vm))
        {
            var command = _mapper.Map<UpsertServiceCommand>(vm.Item);
            await _offerService.Create(command);
            await LoadItems();
        }
    }

    public override Task<IReadOnlyList<ServiceDto>> GetItems()
        => _offerService.GetAll();

    public override IReadOnlyList<string> GetItemSearchProperties(ServiceDto service)
    {
        return new List<string>
        {
            service.Name,
            service.JuniorSkill?.Cost.ToString()!,
            service.MiddleSkill?.Cost.ToString()!,
            service.SeniorSkill?.Cost.ToString()!,
        };
    }

    public async Task EditItem(object obj)
    {
        await Execute(async () =>
        {
            if (obj is int serviceId)
            {
                var tempService = await _offerService.GetById(serviceId);

                var currentService = await _offerService.GetById(serviceId);
                var vm = new EditServiceViewModel(currentService);

                if (_dialogService.ShowDialog(typeof(EditServicePage), vm))
                {
                    var command = _mapper.Map<UpsertServiceCommand>(vm.Item);

                    if (tempService.JuniorSkill != null && command.JuniorSkill != null)
                        command.JuniorSkill.Id = tempService.JuniorSkill.Id;

                    if (tempService.MiddleSkill != null && command.MiddleSkill != null)
                        command.MiddleSkill.Id = tempService.MiddleSkill.Id;

                    if (tempService.SeniorSkill != null && command.SeniorSkill != null)
                        command.SeniorSkill.Id = tempService.SeniorSkill.Id;

                    await _offerService.Update(command);
                    await LoadItems();
                }
            }
        });
    }

    public async Task RemoveItem(object obj)
    {
        await Execute(async () =>
        {
            if (obj is int serviceId)
            {
                await _offerService.RemoveById(serviceId);
                await LoadItems();
            }
        });
    }

    // Скрытие базового метода, для использования своего
    public override Task RemoveItem()
        => throw new NotImplementedException();

    // Скрытие базового метода, для использования своего
    public override Task EditItem()
        => throw new NotImplementedException();
}
