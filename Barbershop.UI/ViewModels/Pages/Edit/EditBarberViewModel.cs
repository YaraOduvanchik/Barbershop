using Barbershop.Contracts.Models;
using Barbershop.UI.Services;
using Barbershop.UI.ViewModels.Base;
using DevExpress.Mvvm;
using System.Windows.Input;

namespace Barbershop.UI.ViewModels.Pages.Edit;

public class EditBarberViewModel : EditViewModel<BarberDto>
{
    private readonly IWindowDialogService _dialogService;

    public ICommand SelectImageCommand { get; }
    public ICommand RemoveImageCommand { get; }

    public IReadOnlyList<BarberSkillLevel> BarberSkillLevels
        => Enum.GetValues<BarberSkillLevel>().Cast<BarberSkillLevel>().ToList();

    public EditBarberViewModel(BarberDto itemViewModel, IWindowDialogService dialogService)
        : this(dialogService)
    {
        Item = itemViewModel;
        Title = $"Редактирование {_viewModelName}";
    }

    public EditBarberViewModel(IWindowDialogService dialogService, Action<BarberDto> preUpdate = null)
        : base(preUpdate)
    {
        _dialogService = dialogService ?? throw new ArgumentNullException(nameof(dialogService));

        SelectImageCommand = new DelegateCommand(SelectImage);
        RemoveImageCommand = new DelegateCommand(RemoveImage);

        Args!.MinBirthdayDate = DateTime.Now.AddYears(-18);
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

        if (string.IsNullOrWhiteSpace(Item.Login))
            errors.Add("Введите логин.");

        if (Item.Id == 0 && string.IsNullOrWhiteSpace(Args.Password as string))
            errors.Add("Пароль при создании учетной записи обязателен.");

        if (string.IsNullOrWhiteSpace(Item.FirstName))
            errors.Add("Введите имя.");

        if (string.IsNullOrWhiteSpace(Item.PhoneNumber))
            errors.Add("Введите телефон.");

        return errors;
    }
}
