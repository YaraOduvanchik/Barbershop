using Barbershop.UI.ViewModels.Pages.Edit;
using System.Windows.Controls;

namespace Barbershop.UI.Views.Pages.Edit;

/// <summary>
/// Логика взаимодействия для EditBarberPage.xaml
/// </summary>
public partial class EditBarberPage : UserControl
{
    public EditBarberPage(EditBarberViewModel context)
    {
        InitializeComponent();
        DataContext = context;
    }
}
