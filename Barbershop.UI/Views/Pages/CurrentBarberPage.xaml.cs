using Barbershop.UI.ViewModels.Pages;
using System.Windows.Controls;

namespace Barbershop.UI.Views.Pages;

/// <summary>
/// Логика взаимодействия для CurrentBarberPage.xaml
/// </summary>
public partial class CurrentBarberPage : Page
{
    public CurrentBarberPage(CurrentBarberViewModel context)
    {
        InitializeComponent();
        DataContext = context;
    }
}
