using Barbershop.UI.ViewModels.Pages.Edit;
using System.Windows.Controls;

namespace Barbershop.UI.Views.Pages.Edit;

/// <summary>
/// Логика взаимодействия для CreateOrderPage.xaml
/// </summary>
public partial class CreateOrderPage : UserControl
{
    public CreateOrderPage(CreateOrderViewModel context)
    {
        InitializeComponent();
        DataContext = context;
    }
}
