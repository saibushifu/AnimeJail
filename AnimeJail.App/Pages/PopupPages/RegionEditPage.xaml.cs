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
        public Region? EditRegion { get; set; } = null;
        public RegionEditPage()
        {
            BaseCtorConfig();
        }
        public RegionEditPage(Region editRegion)
        {
            EditRegion = editRegion;
            DataContext = this;
            BaseCtorConfig();
        }

        private void BaseCtorConfig()
        {
            InitializeComponent();
            cbCountry.ItemsSource = DataFromDb.CountryCollection;

            if (EditRegion != null) cbCountry.SelectedValue = EditRegion.CountryId;
        }

        private void AddRegionButtonClick(object sender, RoutedEventArgs e)
        {
            //try
            //{
            //    var newRegion = new Region
            //    {
            //        Id = Convert.ToInt32(tbId.cText),
            //        CountryId = Convert.ToInt32(cbCountry.SelectedValue),
            //        Name = tbName.cText
            //    };
            //    App.Context.Add(newRegion);
            //    App.Context.SaveChanges();
            //    DataFromDb.RegionsCollection.Add(newRegion);
            //    MessageBox.Show("Операция выполнена успешно");
            //}
            //catch (Exception ex) { MessageBox.Show(ex.Message); }

            var isRegionNull = EditRegion == null;

            Region currentRegion = isRegionNull ? new Region { } : App.Context.Regions.First(x => x.Id == EditRegion.Id);
            currentRegion.Id = Convert.ToInt32(tbId.cText);
            currentRegion.CountryId = Convert.ToInt32(cbCountry.SelectedValue);
            currentRegion.Name = tbName.cText;

            CommonDataFunc<Region>.AddObjToDb(isRegionNull, App.Context.Regions, currentRegion, DataFromDb.RegionsCollection,
                isRegionNull ? null : DataFromDb.RegionsCollection.First(x => x.Id == EditRegion.Id));
        }

        private void AddCountryButtonClick(object sender, RoutedEventArgs e) =>
    new PopupWindow(new CountryEditPage()).Show();

        private void ClearPageButtonClick(object sender, RoutedEventArgs e) =>
            NavigationService.Navigate(EditRegion == null ? new RegionEditPage() : new RegionEditPage(EditRegion));
    }
}
