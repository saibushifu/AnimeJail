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
using System.Runtime.InteropServices;
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
        public Address? EditAddress { get; set; } = null;
        public AddressEditPage()
        {
            BaseCtorConfig();
        }

        public AddressEditPage(Address editAddress)
        {
            EditAddress = editAddress;
            DataContext = this;
            BaseCtorConfig();
        }

        private void BaseCtorConfig()
        {
            InitializeComponent();
            UpdateContext();
            cbCountry.ItemsSource = DataFromDb.CountryCollection;
        }

        private void OpenPage(Page page)
        {
            new PopupWindow(page).ShowDialog();
            UpdateContext();
        }

        private void UpdateContext()
        {
            if (EditAddress != null)
            {
                cbCountry.SelectedValue = EditAddress.City.CountryId;
                cbRegion.SelectedValue = EditAddress.City.RegionId;
                cbCity.SelectedValue = EditAddress.City.Id;
            }
            cbRegion.ItemsSource = DataFromDb.RegionsCollection.Where(x => x.CountryId == Convert.ToInt32(cbCountry.SelectedValue)).ToList();
            cbCity.ItemsSource = cbRegion.SelectedValue != null ? DataFromDb.CitiesCollection.Where(x => x.RegionId == Convert.ToInt32(cbRegion.SelectedValue)).ToList() : null;
        }

        private void AddCountryButtonClick(object sender, RoutedEventArgs e) => OpenPage(new CountryEditPage());
        private void AddRegionButtonClick(object sender, RoutedEventArgs e) => OpenPage(new RegionEditPage());
        private void AddCityButtonClick(object sender, RoutedEventArgs e) => OpenPage(new CityEditPage());

        private void AddAddressButtonClick(object sender, RoutedEventArgs e)
        {
            var isAddressNull = EditAddress == null;

            Address currentCountry = isAddressNull ? new Address { } : App.Context.Addresses.First(x => x.Id == EditAddress.Id);
            currentCountry.CityId = Convert.ToInt32(cbCountry.SelectedValue);
            currentCountry.StreetName = tbStreet.cText;
            currentCountry.ApartmentNumber = tbApartment.cText;
            currentCountry.BuildingNumber = tbBuilding.cText;

            CommonDataFunc<Address>.AddObjToDb(isAddressNull, App.Context.Addresses, currentCountry, 
                DataFromDb.AddressCollection, isAddressNull ? null : DataFromDb.AddressCollection.First(x => x.Id == EditAddress.Id));
        }

        private void CbSelectionChanged(object sender, SelectionChangedEventArgs e) => UpdateContext();

        private void ClearPageButtonClick(object sender, RoutedEventArgs e) =>
            NavigationService.Navigate(EditAddress == null ? new AddressEditPage() : new AddressEditPage(EditAddress));

    }

}
