using Barbershop.UI.ViewModels.Pages.Edit;
using System.Windows.Controls;

namespace Barbershop.UI.Views.Pages.Edit;

/// <summary>
/// Логика взаимодействия для EditClientPage.xaml
/// </summary>
public partial class EditClientPage : UserControl
{
    public EditClientPage(EditClientViewModel context)
    {
        InitializeComponent();
        DataContext = context;
    }
}
