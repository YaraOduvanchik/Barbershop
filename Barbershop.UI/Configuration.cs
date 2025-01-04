using Barbershop.UI.Services;
using Barbershop.UI.ViewModels;
using Barbershop.UI.ViewModels.Pages;
using Barbershop.UI.ViewModels.Pages.Edit;
using Barbershop.UI.Views;
using Barbershop.UI.Views.Pages;
using Barbershop.UI.Views.Pages.Edit;
using Microsoft.Extensions.DependencyInjection;

namespace Barbershop.UI;

internal static class Configuration
{
    public static ServiceCollection RegisterViews(this ServiceCollection serviceCollection)
    {
        serviceCollection.AddTransient<AuthView>();
        serviceCollection.AddTransient<AuthViewModel>();

        serviceCollection.AddTransient<MainView>();
        serviceCollection.AddTransient<MainViewModel>();

        serviceCollection.AddPages();

        return serviceCollection;
    }

    private static ServiceCollection AddPages(this ServiceCollection serviceCollection)
    {
        serviceCollection.AddSingleton<MainPage>();

        serviceCollection.AddSingleton<AdminsPage>();
        serviceCollection.AddSingleton<AdminsPageViewModel>();

        serviceCollection.AddSingleton<SalaryPage>();
        serviceCollection.AddSingleton<SalaryPageViewModel>();

        serviceCollection.AddSingleton<SalaryPageAdmin>();
        serviceCollection.AddSingleton<SalaryPageAdminViewModel>();

        serviceCollection.AddSingleton<CurrentBarberPage>();
        serviceCollection.AddSingleton<CurrentBarberViewModel>();

        serviceCollection.AddSingleton<BarbersPage>();
        serviceCollection.AddSingleton<BarbersPageViewModel>();

        serviceCollection.AddSingleton<ClientsPage>();
        serviceCollection.AddSingleton<ClientsPageViewModel>();

        serviceCollection.AddSingleton<ProductsPage>();
        serviceCollection.AddSingleton<ProductsPageViewModel>();

        serviceCollection.AddSingleton<ServicesPage>();
        serviceCollection.AddSingleton<ServicesPageViewModel>();

        serviceCollection.AddSingleton<OrdersPage>();
        serviceCollection.AddSingleton<OrdersPageViewModel>();

        serviceCollection.AddTransient<CreateOrderPage>();
        serviceCollection.AddTransient<CreateOrderViewModel>();

        return serviceCollection;
    }

    public static ServiceCollection RegisterExternalServices(this ServiceCollection serviceCollection)
    {
        serviceCollection.AddTransient<IWindowDialogService, WindowDialogService>();

        return serviceCollection;
    }
}
