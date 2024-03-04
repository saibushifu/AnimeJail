using AnimeJail.App.Methods;
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
    /// Логика взаимодействия для AddressViewPage.xaml
    /// </summary>
    public partial class AddressViewPage : Page
    {
        public AddressViewPage()
        {
            InitializeComponent();
            dgAdress.ItemsSource = DataFromDb.AddressCollection;
            cbCountry.ItemsSource = DataFromDb.CountryCollection;
            UpdateContext();
        }
        private void UpdateContext()
        {
            cbRegion.ItemsSource = DataFromDb.RegionsCollection.Where(x => x.CountryId == Convert.ToInt32(cbCountry.SelectedValue)).ToList();
            cbCity.ItemsSource = cbRegion.SelectedValue != null ? DataFromDb.CitiesCollection.Where(x => x.RegionId == Convert.ToInt32(cbRegion.SelectedValue)).ToList() : null;
        }

        private void AddressAddButtonClick(object sender, RoutedEventArgs e) =>
            new PopupWindow(new AddressEditPage()).Show();

        private void ListUpdate()
        {

        }
    }
}
