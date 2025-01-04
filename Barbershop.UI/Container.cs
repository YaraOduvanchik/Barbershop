using Barbershop.DAL;
using Barbershop.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;

namespace Barbershop.UI;

/// <summary>
/// Класс для управления зависимостями сущностей.
/// </summary>
public static class Container
{
    public static IServiceProvider ServiceProvider { get; }

    static Container()
    {
        ServiceProvider = CreateServiceCollection();
    }

    private static IServiceProvider CreateServiceCollection()
    {
        var serviceCollection = new ServiceCollection();

        serviceCollection
            .RegisterDataAccessLayerServices()
            .RegisterServices()
            .RegisterExternalServices()
            .RegisterViews();

        serviceCollection.AddAutoMapper(Assembly.GetExecutingAssembly());

        return serviceCollection.BuildServiceProvider();
    }

    public static void PrepareApp()
    {
        Task.Run(() => ServiceProvider.Migrate()).Wait();
    }

    public static Page? GetPage(Type pageType)
    {
        return (Page?)ServiceProvider.GetService(pageType);
    }

    public static void ShowView<T>() where T : Window
    {
        ServiceProvider.GetRequiredService<T>().ShowDialog();
    }
}
