using Barbershop.UI.ViewModels.Pages;
using System.Windows.Controls;

namespace Barbershop.UI.Views.Pages;
/// <summary>
/// Логика взаимодействия для BarbersPage.xaml
/// </summary>
public partial class BarbersPage : Page
{
    public BarbersPage(BarbersPageViewModel context)
    {
        InitializeComponent();
        DataContext = context;
    }
}
