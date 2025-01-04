using Barbershop.Contracts.Models;
using Barbershop.UI.Views;
using DevExpress.Mvvm;
using HandyControl.Themes;
using HandyControl.Tools;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;

namespace Barbershop.UI;

public partial class App : Application
{
    public static AuthorizedUserDto CurrentUser { get; set; }

    public static ICommand ChangeThemeCommand { get; }
    public static ICommand ChangeAccountCommand { get; }

    static App()
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        ThemeManager.Current.ApplicationTheme = ApplicationTheme.Light;

        ChangeThemeCommand = new DelegateCommand<ApplicationTheme>(ChangeTheme);
        ChangeAccountCommand = new DelegateCommand(ChangeAccount);
    }

    private static void ChangeTheme(ApplicationTheme selectedTheme)
    {
        if (selectedTheme == ThemeManager.Current.ApplicationTheme)
            return;

        ThemeAnimationHelper.AnimateTheme(Application.Current.MainWindow, ThemeAnimationHelper.SlideDirection.Top, 0.3, 1, 0.5);
        ThemeManager.Current.ApplicationTheme = selectedTheme;
        ThemeAnimationHelper.AnimateTheme(Application.Current.MainWindow, ThemeAnimationHelper.SlideDirection.Bottom, 0.3, 0.5, 1);
    }

    private static void ChangeAccount()
    {
        Process.Start(Environment.ProcessPath!);
        Application.Current.Shutdown();
    }

    protected override void OnStartup(StartupEventArgs e)
    {
        Container.PrepareApp();

        Container.ShowView<AuthView>();
    }
}
