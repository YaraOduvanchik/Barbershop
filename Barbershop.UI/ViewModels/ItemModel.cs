namespace Barbershop.UI.ViewModels;

/// <summary>
/// Модель, описывающая элемент списка меню.
/// </summary>
public class ItemModel
{
    public string Header { get; set; }

    public string ImageName { get; set; }

    public Type PageType { get; set; }

    public ItemModel(string header, string imageName, Type pageType = default)
    {
        Header = header;
        ImageName = imageName;
        PageType = pageType;
    }
}
