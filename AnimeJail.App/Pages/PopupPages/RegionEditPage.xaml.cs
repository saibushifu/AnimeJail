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
    /// Логика взаимодействия для RegionEditPage.xaml
    /// </summary>
    public partial class RegionEditPage : Page
    {
        private Region? EditRegion = null;
        public RegionEditPage()
        {
            InitializeComponent();
            cbCountry.ItemsSource = DataFromDb.CountryCollection;
        }
        public RegionEditPage(Region editRegion) : this()
        {
            EditRegion = editRegion;
        }

        private void AddRegionButtonClick(object sender, RoutedEventArgs e)
        {
            try
            {
                var newRegion = new Region
                {
                    Id = Convert.ToInt32(tbId.cText),
                    CountryId = Convert.ToInt32(cbCountry.SelectedValue),
                    Name = tbName.cText
                };
                App.Context.Add(newRegion);
                App.Context.SaveChanges();
                DataFromDb.RegionsCollection.Add(newRegion);
                MessageBox.Show("Операция выполнена успешно");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void AddCountryButtonClick(object sender, RoutedEventArgs e) =>
    new PopupWindow(new CountryEditPage()).Show();

        private void ClearPageButtonClick(object sender, RoutedEventArgs e) =>
            NavigationService.Navigate(EditRegion == null ? new RegionEditPage() : new RegionEditPage(EditRegion));
    }
}
