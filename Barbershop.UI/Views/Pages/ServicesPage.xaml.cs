using Barbershop.UI.ViewModels.Pages;
using System.Windows.Controls;

namespace Barbershop.UI.Views.Pages;

/// <summary>
/// Логика взаимодействия для ServicesPage.xaml
/// </summary>
public partial class ServicesPage : Page
{
    public ServicesPage(ServicesPageViewModel context)
    {
        InitializeComponent();
        DataContext = context;
    }
}
