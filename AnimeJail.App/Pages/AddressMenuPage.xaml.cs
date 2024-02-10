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

namespace AnimeJail.App.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddressMenuPage.xaml
    /// </summary>
    public partial class AddressMenuPage : Page
    {
        public AddressMenuPage()
        {
            InitializeComponent();
        }

        private void AddressButtonClick(object sender, RoutedEventArgs e) =>
            NavigationService.Navigate(new AddressViewPage());
        private void CountryButtonClick(object sender, RoutedEventArgs e) =>
            NavigationService.Navigate(new CountryViewPage());
        private void RegionButtonClick(object sender, RoutedEventArgs e) =>
            NavigationService.Navigate(new RegionViewPage());
        private void CityButtonClick(object sender, RoutedEventArgs e) =>
            NavigationService.Navigate(new CityViewPage());
    }
}
