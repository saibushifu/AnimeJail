using AnimeJail.App.Methods;
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
    /// Логика взаимодействия для CityEditPage.xaml
    /// </summary>
    public partial class CityEditPage : Page
    {
        public CityEditPage()
        {
            InitializeComponent();
            cbCountry.ItemsSource = DataFromDb.RegionsCollection;
            UpdateContext();
        }

        public CityEditPage(City editCity) : this()
        {

        }

        private void UpdateContext()
        {
            cbRegion.ItemsSource = DataFromDb.RegionsCollection.Where(x => x.CountryId == Convert.ToInt32(cbCountry.SelectedValue)).ToList();
        }

        private void AddCityButtonClick(object sender, RoutedEventArgs e)
        {
            try
            {
                App.Context.Add(new City
                {
                    Id = Convert.ToInt32(tbId.cText),
                    Name = tbName.cText,
                    Country = cbCountry.SelectedValue as Country,
                    Region = cbRegion.SelectedValue as Region
                });
                App.Context.SaveChanges();
                MessageBox.Show("Операция выполнена успешно");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void AddCountryButtonClick(object sender, RoutedEventArgs e) =>
            new PopupWindow(new CountryEditPage()).Show();

        private void AddRegionButtonClick(object sender, RoutedEventArgs e) =>
           new PopupWindow(new RegionEditPage()).Show();

        private void CountrySelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateContext();
        }
    }
}
