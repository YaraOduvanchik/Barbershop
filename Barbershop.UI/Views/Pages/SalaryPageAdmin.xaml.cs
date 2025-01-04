using Barbershop.UI.ViewModels.Pages;
using System.Windows.Controls;

namespace Barbershop.UI.Views.Pages;

/// <summary>
/// Логика взаимодействия для SalaryPageAdmin.xaml
/// </summary>
public partial class SalaryPageAdmin : Page
{
    public SalaryPageAdmin(SalaryPageAdminViewModel context)
    {
        InitializeComponent();
        DataContext = context;
    }
}
