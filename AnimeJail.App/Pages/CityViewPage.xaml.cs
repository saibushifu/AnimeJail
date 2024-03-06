using AnimeJail.App.Methods;
using AnimeJail.App.Models;
using AnimeJail.App.Pages.PopupPages;
using System.Windows;
using System.Windows.Controls;

namespace AnimeJail.App.Pages;

/// <summary>
/// Логика взаимодействия для CityViewPage.xaml
/// </summary>
public partial class CityViewPage : Page
{
    public CityViewPage()
    {
        InitializeComponent();
        dgCities.ItemsSource = DataFromDb.CitiesCollection;
        cbCountry.ItemsSource = DataFromDb.CountryCollection;
        UpdateContext();
    }

    private void UpdateContext()
    {
        cbRegion.ItemsSource = DataFromDb.RegionsCollection.Where(x => x.CountryId == Convert.ToInt32(cbCountry.SelectedValue)).ToList();
    }
    private void CityAddButtonClick(object sender, RoutedEventArgs e) => CommonPageFunc.OpenPage(new CityEditPage(new City { }));
    private void ListUpdate()
    {

    }
    private void DeleteCityButtonClick(object sender, RoutedEventArgs e) => CommonDataFunc<City>.DeleteObjFromDb(sender, DataFromDb.CitiesCollection);
    private void EditCityButtonClick(object sender, RoutedEventArgs e) => CommonPageFunc.OpenPage(new CityEditPage(CommonDataFunc<City>.TypeFromSender(sender)));
}
