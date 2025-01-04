using Barbershop.UI.Services;
using System.Dynamic;

namespace Barbershop.UI.ViewModels.Base;

/// <summary>
/// Модель редактирования сущности.
/// </summary>
/// <typeparam name="T"></typeparam>
public class EditViewModel<T> : EditViewModel where T : class, new()
{
    protected string _viewModelName = ViewPrefixService.Get<T>();

    public dynamic? Args { get; set; }

    public T Item
    {
        get => GetValue<T>(nameof(Item));
        set => SetValue(value, nameof(Item));
    }

    public EditViewModel(T itemViewModel, dynamic? args = null)
    {
        Item = itemViewModel;
        Title = $"Редактирование {_viewModelName}";
        Args = args ?? new ExpandoObject();
    }

    public EditViewModel(Action<T>? preUpdate = default, dynamic? args = null)
    {
        Item = new T();
        Title = $"Создание {_viewModelName}";
        Args = args ?? new ExpandoObject();

        preUpdate?.Invoke(Item);
    }
}

public abstract class EditViewModel : BaseViewModel
{
    public virtual IReadOnlyList<string> GetErrors()
        => Array.Empty<string>();
}