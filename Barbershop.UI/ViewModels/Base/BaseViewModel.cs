using Barbershop.UI.Services;
using DevExpress.Mvvm;
using HandyControl.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Barbershop.UI.ViewModels.Base;

/// <summary>
/// Базовая модель для всех моделей представления в приложении.
/// </summary>
public abstract class BaseViewModel : ViewModelBase
{
    // Название View (окна)
    public virtual string Title { get; protected set; }
    public virtual ImageSource IconImage => new BitmapImage(new("/TechStore.UI;component/Resources/Images/Logo.png"));

    public ICommand LoadViewDataCommand { get; set; }

    // Флаг для отображения индикатора загрузки при выполнении асинхронных действий
    public bool IsUploading
    {
        get => GetValue<bool>(nameof(IsUploading));
        set => SetValue(value, nameof(IsUploading));
    }

    public BaseViewModel()
    {
        Title = ViewTitleService.Get(this);
    }

    // Метод, устанавливающий флаг и выполняющий передаваемую функцию
    public async Task Execute(Func<Task> action)
    {
        IsUploading = true;
        await Task.Delay(50);

        try
        {
            await action();
        }
        catch (Exception ex)
        {
            // Вывод ошибки в унифицированном окне
            MessageBox.Error(ex.Message, "Ошибка выполнения операции");
        }
        finally
        {
            IsUploading = false;
        }
    }

    // Повторный вызов переданной функции с задержкой
    public async Task RepeatExecute(Func<Task> action, TimeSpan interval)
    {
        IsUploading = true;
        await Task.Delay(1000);

        _ = Task.Run(async () =>
        {
            while (true)
            {
                action?.Invoke();
                await Task.Delay(interval);
            }
        });

        IsUploading = false;
    }
}
