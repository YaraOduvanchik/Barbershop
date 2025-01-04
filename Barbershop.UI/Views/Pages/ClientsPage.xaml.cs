using Barbershop.UI.ViewModels.Pages;
using System.Windows.Controls;

namespace Barbershop.UI.Views.Pages;
/// <summary>
/// Логика взаимодействия для ClientsPage.xaml
/// </summary>
public partial class ClientsPage : Page
{
    public ClientsPage(ClientsPageViewModel context)
    {
        InitializeComponent();
        DataContext = context;
    }
}
