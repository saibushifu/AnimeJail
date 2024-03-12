using AnimeJail.App.Methods;
using AnimeJail.App.Models;
using AnimeJail.App.Pages.PopupPages;
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

namespace AnimeJail.App.Pages;

/// <summary>
/// Логика взаимодействия для BerthViewPage.xaml
/// </summary>
public partial class BerthViewPage : Page
{
    public BerthViewPage()
    {
        InitializeComponent();
        dgBerth.ItemsSource = DataFromDb.BerthCollection;
    }

    private void AddBerthButtonClick(object sender, RoutedEventArgs e) => CommonPageFunc.OpenPage(new BerthEditPage());
    private void DeleteBerthButtonClick(object sender, RoutedEventArgs e) => CommonDataFunc<Berth>.DeleteObjFromDb(sender, DataFromDb.BerthCollection);

    private void EditBerthButtonClick(object sender, RoutedEventArgs e) =>
        CommonPageFunc.OpenPage(new BerthEditPage(CommonDataFunc<Berth>.TypeFromSender(sender)));
}
