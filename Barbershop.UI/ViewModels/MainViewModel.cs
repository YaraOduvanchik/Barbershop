using Barbershop.UI.Services;
using Barbershop.UI.ViewModels.Base;
using Barbershop.UI.Views.Pages;
using DevExpress.Mvvm;
using HandyControl.Controls;
using HandyControl.Data;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace Barbershop.UI.ViewModels;

/// <summary>
/// Модель главного окна приложения.
/// </summary>
public class MainViewModel : BaseViewModel
{
    public Page CurrentPage
    {
        get => GetValue<Page>(nameof(CurrentPage));
        set => SetValue(value, nameof(CurrentPage));
    }

    public ICommand SwitchItemCommand { get; }

    public MainViewModel()
    {
        LoadViewDataCommand = new DelegateCommand<SideMenu>(LoadData);

        SwitchItemCommand = new DelegateCommand<FunctionEventArgs<object>>(SwitchItem);
    }

    public void LoadData(SideMenu sideMenu)
    {
        foreach (var item in ViewItemsManager.GetItems())
        {
            var menuItem = new SideMenuItem()
            {
                Header = $"   {item.Header}",
                Icon = string.IsNullOrEmpty(item.ImageName)
                    ? null
                    : new Image()
                    {
                        Source = System.Windows.Application.Current.FindResource(item.ImageName) as BitmapImage,
                        Width = 46,
                        Height = 46
                    },
                Tag = item.PageType
            };

            sideMenu.Items.Add(menuItem);
        }

        (sideMenu.Items[0] as SideMenuItem)!.IsSelected = true;
        CurrentPage = Container.GetPage(typeof(MainPage))!;
    }

    public void SwitchItem(FunctionEventArgs<object> args)
    {
        CurrentPage = Container.GetPage(((args.Info as SideMenuItem)!.Tag as Type)!)!;
    }
}
