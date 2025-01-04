using Barbershop.UI.ViewModels.Pages;
using System.Windows.Controls;

namespace Barbershop.UI.Views.Pages;

/// <summary>
/// Логика взаимодействия для AdminsPage.xaml
/// </summary>
public partial class AdminsPage : Page
{
    public AdminsPage(AdminsPageViewModel context)
    {
        InitializeComponent();
        DataContext = context;
    }
}
