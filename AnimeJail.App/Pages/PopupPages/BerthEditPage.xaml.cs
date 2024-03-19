using AnimeJail.App.Methods;
using AnimeJail.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace AnimeJail.App.Pages.PopupPages;

/// <summary>
/// Логика взаимодействия для BerthEditPage.xaml
/// </summary>
public partial class BerthEditPage : Page
{
    public Berth? EditBerth { get; set; } = null;
    public BerthEditPage() => BaseCtorConfig();
    public BerthEditPage(Berth editBerth)
    {
        EditBerth = editBerth;
        DataContext = this;
        BaseCtorConfig();
    }
    private void BaseCtorConfig()
    {
        InitializeComponent();
        cbJail.ItemsSource = DataFromDb.JailCollection;
    }
    private void AddJailButtonClick(object sender, RoutedEventArgs e) => CommonPageFunc.OpenPage(new PrisonCellEditPage());
    private void ClearPageButtonClick(object sender, RoutedEventArgs e) =>
           NavigationService.Navigate(EditBerth == null ? new BerthEditPage() : new BerthEditPage(EditBerth));

    private void AddBerthButtonClick(object sender, RoutedEventArgs e)
    {
        var isBerthNull = EditBerth == null;

        Berth currentBerth = isBerthNull ? new Berth { } : App.Context.Berths.First(x => x.Id == EditBerth.Id);
        currentBerth.Name = tbId.cText;
        currentBerth.JailId = Convert.ToInt32(cbJail.SelectedValue);

        CommonDataFunc<Berth>.AddObjToDb(isBerthNull, App.Context.Berths, currentBerth, DataFromDb.BerthCollection,
            isBerthNull ? null : DataFromDb.BerthCollection.First(x => x.Id == EditBerth.Id));
    }
}
