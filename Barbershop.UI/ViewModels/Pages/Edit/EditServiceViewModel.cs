using Barbershop.Contracts.Models;
using Barbershop.UI.ViewModels.Base;
using DevExpress.Mvvm;
using System.Windows.Input;

namespace Barbershop.UI.ViewModels.Pages.Edit;

public class EditServiceViewModel : EditViewModel<ServiceDto>
{
    public ICommand AddJuniorServiceCommand { get; }
    public ICommand RemoveJuniorServiceCommand { get; }

    public ICommand AddMiddleServiceCommand { get; }
    public ICommand RemoveMiddleServiceCommand { get; }

    public ICommand AddSeniorServiceCommand { get; }
    public ICommand RemoveSerniorServiceCommand { get; }

    public EditServiceViewModel(ServiceDto itemViewModel)
        : this()
    {
        Item = itemViewModel;
    }

    public EditServiceViewModel()
        : base(preUpdate: null)
    {
        AddJuniorServiceCommand = new DelegateCommand(() => Item.JuniorSkill = new ServiceSkillLevelDto());
        RemoveJuniorServiceCommand = new DelegateCommand(() => Item.JuniorSkill = null);

        AddMiddleServiceCommand = new DelegateCommand(() => Item.MiddleSkill = new ServiceSkillLevelDto());
        RemoveMiddleServiceCommand = new DelegateCommand(() => Item.MiddleSkill = null);

        AddSeniorServiceCommand = new DelegateCommand(() => Item.SeniorSkill = new ServiceSkillLevelDto());
        RemoveSerniorServiceCommand = new DelegateCommand(() => Item.SeniorSkill = null);
    }

    public override IReadOnlyList<string> GetErrors()
    {
        var errors = new List<string>();

        if (string.IsNullOrWhiteSpace(Item.Name))
            errors.Add("Введите название услуги.");

        if (Item.JuniorSkill is null || Item.MiddleSkill is null || Item.SeniorSkill == null)
            errors.Add("Заполните все уровни мастерства.");

        return errors;
    }
}
