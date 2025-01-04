using Barbershop.UI.ViewModels;
using HandyControl.Controls;

namespace Barbershop.UI.Views;

/// <summary>
/// Логика взаимодействия для MainView.xaml
/// </summary>
public partial class MainView : Window
{
    public MainView(MainViewModel context)
    {
        InitializeComponent();
        DataContext = context;
    }
}
