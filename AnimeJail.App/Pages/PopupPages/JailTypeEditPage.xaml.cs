using AnimeJail.App.Methods;
using AnimeJail.App.Models;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace AnimeJail.App.Pages.PopupPages;

/// <summary>
/// Логика взаимодействия для JailTypeEditPage.xaml
/// </summary>
public partial class JailTypeEditPage : Page
{
    public JailType? EditJailType { get; set; } = null;
    public JailTypeEditPage() => InitializeComponent();
    public JailTypeEditPage(JailType editJailType)
    {
        EditJailType = editJailType;
        DataContext = this;
        InitializeComponent();
    }

    private void AddJailTypeButtonClick(object sender, RoutedEventArgs e)
    {
        var isJailTypeNull = EditJailType == null;

        JailType currentJailType = isJailTypeNull ? new JailType { } : App.Context.JailTypes.First(x => x.Id == EditJailType.Id);
        //currentJailType.Id = Convert.ToInt32(tbId.cText);
        currentJailType.Name = tbName.cText;

        CommonDataFunc<JailType>.AddObjToDb(isJailTypeNull, App.Context.JailTypes, currentJailType, DataFromDb.JailTypeCollection,
            isJailTypeNull ? null : DataFromDb.JailTypeCollection.First(x => x.Id == EditJailType.Id));

    }
    private void ClearPageButtonClick(object sender, RoutedEventArgs e) =>
        NavigationService.Navigate(EditJailType == null ? new JailTypeEditPage() : new JailTypeEditPage(EditJailType));
}
