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
        public City? EditCity { get; set; } = null;
        public CityEditPage()
        {
            BaseCtorConfig();
        }

        public CityEditPage(City editCity)
        {
            EditCity = editCity;
            DataContext = this;
            BaseCtorConfig();
        }

        private void BaseCtorConfig()
        {
            InitializeComponent();
            if (EditCity != null)
            {
                cbCountry.SelectedValue = EditCity.CountryId;
                cbRegion.SelectedValue = EditCity.RegionId;
            }
            UpdateContext();
            cbCountry.ItemsSource = DataFromDb.CountryCollection;
        }

        private void UpdateContext()
        {
           
            cbRegion.ItemsSource = DataFromDb.RegionsCollection.Where(x => x.CountryId == Convert.ToInt32(cbCountry.SelectedValue)).ToList();
        }

        private void AddCityButtonClick(object sender, RoutedEventArgs e)
        {
          


            var isCityNull = EditCity == null;

            City currentCity = isCityNull ? new City { } : App.Context.Cities.First(x => x.Id == EditCity.Id);
            currentCity.Id = Convert.ToInt32(tbId.cText);
            currentCity.Name = tbName.cText;
            currentCity.CountryId = Convert.ToInt32(cbCountry.SelectedValue);
            currentCity.RegionId = Convert.ToInt32(cbRegion.SelectedValue);

            CommonDataFunc<City>.AddObjToDb(isCityNull, App.Context.Cities, currentCity, DataFromDb.CitiesCollection,
                isCityNull ? null : DataFromDb.CitiesCollection.First(x => x.Id == EditCity.Id));
        }

        private void AddCountryButtonClick(object sender, RoutedEventArgs e) =>
            new PopupWindow(new CountryEditPage()).Show();

        private void AddRegionButtonClick(object sender, RoutedEventArgs e) =>
           new PopupWindow(new RegionEditPage()).Show();

        private void CountrySelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateContext();
        }

        private void ClearPageButtonClick(object sender, RoutedEventArgs e) =>
            NavigationService.Navigate(EditCity == null ? new CityEditPage() : new CityEditPage(EditCity));
    }
}
