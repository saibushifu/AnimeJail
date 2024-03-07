using AnimeJail.App.Methods;
using AnimeJail.App.Models;
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
    /// Логика взаимодействия для CountryEditPage.xaml
    /// </summary>
    public partial class CountryEditPage : Page
    {
        private Country? EditCountry = null;
        public CountryEditPage()
        {
            InitializeComponent();
        }   

        public CountryEditPage(Country editCountry) : this()
        {
            EditCountry = editCountry;
        }

        private void AddCountryButtonClick(object sender, RoutedEventArgs e)
        {
            try
            {
                var newCountry = new Country { Id = Convert.ToInt32(tbId.cText), Name = tbName.cText };
                App.Context.Countries.Add(newCountry);
                App.Context.SaveChanges();
                DataFromDb.CountryCollection.Add(newCountry);
                MessageBox.Show("Операция выполнена успешно");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        private void ClearPageButtonClick(object sender, RoutedEventArgs e) =>
         NavigationService.Navigate(EditCountry == null ? new CountryEditPage() : new CountryEditPage(EditCountry));
    }
}
