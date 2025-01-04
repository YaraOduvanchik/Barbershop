using Barbershop.UI.ViewModels.Pages;
using System.Windows.Controls;

namespace Barbershop.UI.Views.Pages;

/// <summary>
/// Логика взаимодействия для OrdersPage.xaml
/// </summary>
public partial class OrdersPage : Page
{
    public OrdersPage(OrdersPageViewModel context)
    {
        InitializeComponent();
        DataContext = context;
    }
}
