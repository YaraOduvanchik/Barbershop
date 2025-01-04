using Barbershop.UI.ViewModels.Pages;
using System.Windows.Controls;

namespace Barbershop.UI.Views.Pages;

/// <summary>
/// Логика взаимодействия для ProductsPage.xaml
/// </summary>
public partial class ProductsPage : Page
{
    public ProductsPage(ProductsPageViewModel context)
    {
        InitializeComponent();
        DataContext = context;
    }
}
