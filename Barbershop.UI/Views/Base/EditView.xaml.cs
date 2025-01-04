using Barbershop.UI.ViewModels.Base;
using Barbershop.UI.ViewModels.Pages.Edit;
using Barbershop.UI.Views.Pages.Edit;
using HandyControl.Controls;
using System.Windows.Controls;
using Window = HandyControl.Controls.Window;

namespace Barbershop.UI.Views.Base;

/// <summary>
/// Логика взаимодействия для EditView.xaml
/// </summary>
public partial class EditView : Window
{
    private bool _isAccept;

    public ContentControl ContextItem { get; }

    public EditView(string title, ContentControl page)
        : this(page)
    {
        InitializeComponent();
        Title = title;
        DataContext = this;
    }

    public EditView(CreateOrderPage page)
        : this((ContentControl)page)
    {
        InitializeComponent();
        Title = "Создание заказа";
        DataContext = this;

        buttonsGroup.Visibility = System.Windows.Visibility.Collapsed;

        (page.DataContext as CreateOrderViewModel).OnOrderCreateCall += EditView_CreateOrder;
    }

    private EditView(ContentControl page)
    {
        ContextItem = page;
        Left = (System.Windows.SystemParameters.WorkArea.Width / 2) - (ContextItem.Width / 2);
        Top = (System.Windows.SystemParameters.WorkArea.Height / 2) - (ContextItem.Height / 2);
    }

    private void EditView_CreateOrder()
    {
        btnOk_Click(null, null);
    }

    private void btnClose_Click(object sender, System.Windows.RoutedEventArgs e)
    {
        DialogResult = false;
        this.Close();
    }

    private void btnOk_Click(object sender, System.Windows.RoutedEventArgs e)
    {
        var editViewModel = ContextItem.DataContext as EditViewModel;

        if (editViewModel != null)
        {
            var errors = editViewModel.GetErrors();

            if (errors.Any())
            {
                MessageBox.Warning(string.Join(Environment.NewLine, errors), "Заполните нужные поля");
                return;
            }
        }

        DialogResult = true;
        _isAccept = true;
        this.Close();
    }

    private void Window_Closed(object sender, System.EventArgs e)
    {
        if (!_isAccept)
        {
            DialogResult = false;
        }

        if (ContextItem.DataContext is CreateOrderViewModel viewModel)
        {
            viewModel.OnOrderCreateCall -= EditView_CreateOrder;
        }
    }
}
