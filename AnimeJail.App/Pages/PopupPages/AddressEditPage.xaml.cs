using AnimeJail.App.Models;
using AnimeJail.App.Windows;
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

namespace AnimeJail.App.Pages.PopupPages
{
    /// <summary>
    /// Логика взаимодействия для AddressEditPage.xaml
    /// </summary>
    public partial class AddressEditPage : Page
    {
        public AddressEditPage()
        {
            InitializeComponent();
        }
        public AddressEditPage(Address editAddress) : this()
        {
            
        }

        private void AddCountryButtonClick(object sender, RoutedEventArgs e) => 
            new PopupWindow(new CountryEditPage()).Show();

        private void AddRegionButtonClick(object sender, RoutedEventArgs e) =>
            new PopupWindow(new RegionEditPage()).Show();

        private void AddCityButtonClick(object sender, RoutedEventArgs e) =>
            new PopupWindow(new CityEditPage()).Show();

        private void AddAddressButtonClick(object sender, RoutedEventArgs e)
        {

        }
    }
}
