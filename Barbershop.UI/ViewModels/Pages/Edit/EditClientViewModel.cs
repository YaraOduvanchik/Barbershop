using Barbershop.Contracts.Models;
using Barbershop.UI.Services;
using Barbershop.UI.ViewModels.Base;
using DevExpress.Mvvm;
using System.Windows.Input;

namespace Barbershop.UI.ViewModels.Pages.Edit;

public class EditClientViewModel : EditViewModel<ClientDto>
{
    private readonly IWindowDialogService _dialogService;

    public ICommand SelectImageCommand { get; }
    public ICommand RemoveImageCommand { get; }

    public EditClientViewModel(ClientDto itemViewModel, IWindowDialogService dialogService)
        : this(dialogService)
    {
        Item = itemViewModel;
    }

    public EditClientViewModel(IWindowDialogService dialogService, Action<ClientDto> preUpdate = null)
        : base(preUpdate)
    {
        _dialogService = dialogService ?? throw new ArgumentNullException(nameof(dialogService));

        SelectImageCommand = new DelegateCommand(SelectImage);
        RemoveImageCommand = new DelegateCommand(RemoveImage);

        Args!.MinBirthdayDate = DateTime.Now.AddYears(-6);
        Args!.Password = string.Empty;
    }

    private void SelectImage()
    {
        if (_dialogService.SelectImage(out var imageBytes))
        {
            Item.Photo = imageBytes;
            RaisePropertyChanged(nameof(Item));
        }
    }

    private void RemoveImage()
    {
        Item.Photo = Array.Empty<byte>();
        RaisePropertyChanged(nameof(Item));
    }

    public override IReadOnlyList<string> GetErrors()
    {
        var errors = new List<string>();

        if (string.IsNullOrWhiteSpace(Item.FirstName))
            errors.Add("Введите имя.");

        if (string.IsNullOrWhiteSpace(Item.PhoneNumber))
            errors.Add("Введите телефон.");

        return errors;
    }
}
