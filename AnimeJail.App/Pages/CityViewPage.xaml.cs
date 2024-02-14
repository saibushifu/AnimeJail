using AnimeJail.App.Models;
using AnimeJail.App.Pages.PopupPages;
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

namespace AnimeJail.App.Pages
{
    /// <summary>
    /// Логика взаимодействия для CityViewPage.xaml
    /// </summary>
    public partial class CityViewPage : Page
    {
        public CityViewPage()
        {
            InitializeComponent();
            dgCities.ItemsSource = App.Context.Cities.ToList();
            cbCountry.ItemsSource = App.Context.Countries.ToList();
        }

        private void CityAddButtonClick(object sender, RoutedEventArgs e) =>
             new PopupWindow(new CityEditPage(new City { })).Show();
        private void ListUpdate()
        {

        }
    }
}
