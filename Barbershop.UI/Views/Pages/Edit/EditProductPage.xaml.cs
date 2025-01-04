using Barbershop.Contracts.Models;
using Barbershop.UI.ViewModels.Base;
using System.Windows.Controls;

namespace Barbershop.UI.Views.Pages.Edit;
/// <summary>
/// Логика взаимодействия для EditProductPage.xaml
/// </summary>
public partial class EditProductPage : UserControl
{
    public EditProductPage(EditViewModel<ProductDto> context)
    {
        InitializeComponent();
        DataContext = context;
    }
}
