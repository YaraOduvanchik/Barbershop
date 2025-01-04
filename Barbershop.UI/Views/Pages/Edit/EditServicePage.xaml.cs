using Barbershop.UI.ViewModels.Pages.Edit;
using System.Windows.Controls;

namespace Barbershop.UI.Views.Pages.Edit;

/// <summary>
/// Логика взаимодействия для EditServicePage.xaml
/// </summary>
public partial class EditServicePage : UserControl
{
    public EditServicePage(EditServiceViewModel context)
    {
        InitializeComponent();
        DataContext = context;
    }
}
