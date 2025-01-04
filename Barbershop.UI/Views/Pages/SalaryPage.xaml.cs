using Barbershop.UI.ViewModels.Pages;
using System.Windows.Controls;

namespace Barbershop.UI.Views.Pages;

/// <summary>
/// Логика взаимодействия для SalaryPage.xaml
/// </summary>
public partial class SalaryPage : Page
{
    public SalaryPage(SalaryPageViewModel context)
    {
        InitializeComponent();
        DataContext = context;
    }
}
