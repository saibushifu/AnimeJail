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
        public RegionEditPage()
        {
            InitializeComponent();
            cbCountry.ItemsSource = App.Context.Countries.ToList();
        }
        public RegionEditPage(Region editRegion) : this()
        {
        }

        private void AddRegionButtonClick(object sender, RoutedEventArgs e)
        {
            try
            {
                App.Context.Add(new Region
                {
                    Id = Convert.ToInt32(tbId.cText),
                    Country = cbCountry.SelectedValue as Country,
                    Name = tbName.cText
                });
                App.Context.SaveChanges();
                MessageBox.Show("Операция выполнена успешно");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void AddCountryButtonClick(object sender, RoutedEventArgs e) =>
    new PopupWindow(new CountryEditPage()).Show();
    }
}
