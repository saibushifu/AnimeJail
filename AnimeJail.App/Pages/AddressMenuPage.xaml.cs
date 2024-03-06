using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace AnimeJail.App.Pages;

/// <summary>
/// Логика взаимодействия для AddressMenuPage.xaml
/// </summary>
public partial class AddressMenuPage : Page
{
    public AddressMenuPage() => InitializeComponent();
    private void AddressButtonClick(object sender, RoutedEventArgs e) => NavigationService.Navigate(new AddressViewPage());
    private void CountryButtonClick(object sender, RoutedEventArgs e) => NavigationService.Navigate(new CountryViewPage());
    private void RegionButtonClick(object sender, RoutedEventArgs e) => NavigationService.Navigate(new RegionViewPage());
    private void CityButtonClick(object sender, RoutedEventArgs e) => NavigationService.Navigate(new CityViewPage());
}
