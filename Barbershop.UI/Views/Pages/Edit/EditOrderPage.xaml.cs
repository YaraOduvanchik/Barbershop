using Barbershop.UI.ViewModels.Pages.Edit;
using System.Windows.Controls;

namespace Barbershop.UI.Views.Pages.Edit;

/// <summary>
/// Логика взаимодействия для EditOrderPage.xaml
/// </summary>
public partial class EditOrderPage : UserControl
{
    public EditOrderPage(EditOrderViewModel context)
    {
        InitializeComponent();
        DataContext = context;
    }
}
