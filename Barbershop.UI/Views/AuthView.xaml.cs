using Barbershop.UI.ViewModels;
using HandyControl.Controls;

namespace Barbershop.UI.Views;

/// <summary>
/// Логика взаимодействия для AuthView.xaml
/// </summary>
public partial class AuthView : Window
{
    public AuthView(AuthViewModel context)
    {
        InitializeComponent();
        DataContext = context;
    }
}
