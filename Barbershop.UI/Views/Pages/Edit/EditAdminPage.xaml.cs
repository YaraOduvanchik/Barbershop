using Barbershop.UI.ViewModels.Pages.Edit;
using System.Windows.Controls;

namespace Barbershop.UI.Views.Pages.Edit;

/// <summary>
/// Логика взаимодействия для EditAdminPage.xaml
/// </summary>
public partial class EditAdminPage : UserControl
{
    public EditAdminPage(EditAdminViewModel context)
    {
        InitializeComponent();
        DataContext = context;
    }
}
