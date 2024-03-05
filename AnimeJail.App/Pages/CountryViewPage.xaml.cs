using AnimeJail.App.Methods;
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
    /// Логика взаимодействия для CountryViewPage.xaml
    /// </summary>
    public partial class CountryViewPage : Page
    {
        public CountryViewPage()
        {
            InitializeComponent();
            dgCountry.ItemsSource = DataFromDb.CountryCollection;
        }

        private void CountryAddButtonClick(object sender, RoutedEventArgs e) =>
         new PopupWindow(new CountryEditPage()).Show();
        private void ListUpdate()
        {

        }

        private void DeleteCountryButtonClick(object sender, RoutedEventArgs e)
        {
            CommonDataFunc<Country>.DeleteObjFromDb(sender, DataFromDb.CountryCollection);
        }

        private void EditCountryButtonClick(object sender, RoutedEventArgs e)
        {

        }
    }
}
