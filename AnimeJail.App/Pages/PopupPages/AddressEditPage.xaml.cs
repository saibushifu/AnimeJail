using AnimeJail.App.Methods;
using AnimeJail.App.Models;
using AnimeJail.App.Windows;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics.Metrics;
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
            UpdateContext();
            cbCountry.ItemsSource = DataFromDb.CountryCollection;
        }

        public AddressEditPage(Address editAddress) : this()
        {

        }

        private void OpenPage(Page page)
        {
            new PopupWindow(page).ShowDialog();
            UpdateContext();
        }

        private void UpdateContext()
        {
            cbRegion.ItemsSource = DataFromDb.RegionsCollection.Where(x => x.CountryId == Convert.ToInt32(cbCountry.SelectedValue)).ToList();
            cbCity.ItemsSource = cbRegion.SelectedValue != null ? DataFromDb.CitiesColliction.Where(x => x.RegionId == Convert.ToInt32(cbRegion.SelectedValue)).ToList() : null;
        }

        private void AddCountryButtonClick(object sender, RoutedEventArgs e) => OpenPage(new CountryEditPage());
        private void AddRegionButtonClick(object sender, RoutedEventArgs e) => OpenPage(new RegionEditPage());
        private void AddCityButtonClick(object sender, RoutedEventArgs e) => OpenPage(new CityEditPage());

        private void AddAddressButtonClick(object sender, RoutedEventArgs e)
        {
            try
            {
                App.Context.Addresses.Add(new Address
                {
                    CityId = Convert.ToInt32(cbCity.SelectedValue),
                    StreetName = tbStreet.cText,
                    ApartmentNumber = tbApartment.cText,
                    BuildingNumber = tbBuilding.cText
                });
                App.Context.SaveChanges();
                MessageBox.Show("Операция выполнена успешно");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void CbSelectionChanged(object sender, SelectionChangedEventArgs e) => UpdateContext();
    }
    
}
