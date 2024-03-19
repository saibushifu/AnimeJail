using AnimeJail.App.Methods;
using AnimeJail.App.Models;
using AnimeJail.App.Pages.PopupPages;
using System.Windows;
using System.Windows.Controls;

namespace AnimeJail.App.Pages;

/// <summary>
/// Логика взаимодействия для CountryViewPage.xaml
/// </summary>
public partial class CountryViewPage : Page
{
    public CountryViewPage()
    {
        InitializeComponent();
        dgCountry.ItemsSource = DataFromDb.CountryCollection;
    }

    private void CountryAddButtonClick(object sender, RoutedEventArgs e) => CommonPageFunc.OpenPage(new CountryEditPage());
    private void ListUpdate()
    {

    }

    private void DeleteCountryButtonClick(object sender, RoutedEventArgs e) =>
        CommonDataFunc<Country>.DeleteObjFromDb(sender, DataFromDb.CountryCollection);
    

    private void EditCountryButtonClick(object sender, RoutedEventArgs e) =>
        CommonPageFunc.OpenPage(new CountryEditPage(CommonDataFunc<Country>.TypeFromSender(sender)));
    
}
