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
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AnimeJail.App.Pages.PopupPages
{
    /// <summary>
    /// Логика взаимодействия для PassportEditPage.xaml
    /// </summary>
    public partial class PassportEditPage : Page
    {
        public PassportDatum? EditPassport { get; set; } = null;
        public PassportEditPage()
        {
            BaseCtorConfig();
        }
        public PassportEditPage(PassportDatum editPassport)
        {
            EditPassport = editPassport;
            DataContext = this;
            BaseCtorConfig();
        }

        private void BaseCtorConfig()
        {
            InitializeComponent();
            cbAdress.ItemsSource = DataFromDb.AddressCollection;
            cbIssuingCountry.ItemsSource = DataFromDb.CountryCollection;

            if(EditPassport != null)
            {
                cbAdress.SelectedValue = EditPassport.DomiclleRegistrationAdressId;
                cbIssuingCountry.SelectedValue = EditPassport.IssuingCountryId;
                dpIssueDate.SelectedDate = EditPassport.IssueDate.ToDateTime(new TimeOnly(0));
            }
        }

        private void AddPassportButtonClick(object sender, RoutedEventArgs e)
        {
            //try
            //{
            //    var newPassport = new PassportDatum
            //    {
            //        Number = Convert.ToInt32(tbNumber.cText),
            //        Serial = Convert.ToInt32(tbSerial.cText),
            //        IssueDate = DateOnly.FromDateTime(dpIssueDate.SelectedDate.Value),
            //        DomiclleRegistrationAdressId = Convert.ToInt32(cbAdress.SelectedValue),
            //        IssuingCountryId = Convert.ToInt32(cbIssuingCountry.SelectedValue)
            //    };
            //    App.Context.Add(newPassport);
            //    App.Context.SaveChanges();
            //    DataFromDb.PassportCollection.Add(newPassport);
            //    MessageBox.Show("Операция выполнена успешно");
            //}
            //catch (Exception ex) { MessageBox.Show(ex.Message); }

            var isPassportNull = EditPassport == null;

            PassportDatum currentPassport = isPassportNull ? new PassportDatum { } : App.Context.PassportData.First(x => x.Id == EditPassport.Id);
            currentPassport.Number = Convert.ToInt32(tbNumber.cText);
            currentPassport.Serial = Convert.ToInt32(tbSerial.cText);
            currentPassport.IssueDate = DateOnly.FromDateTime(dpIssueDate.SelectedDate.Value);
            currentPassport.DomiclleRegistrationAdressId = Convert.ToInt32(cbAdress.SelectedValue);
            currentPassport.IssuingCountryId = Convert.ToInt32(cbIssuingCountry.SelectedValue);

            CommonDataFunc<PassportDatum>.AddObjToDb(isPassportNull, App.Context.PassportData, currentPassport, DataFromDb.PassportCollection,
                isPassportNull ? null : DataFromDb.PassportCollection.First(x => x.Id == EditPassport.Id));

        }

        private void AddAddressButtonClick(object sender, RoutedEventArgs e) =>
            new PopupWindow(new AddressEditPage()).Show();

        private void AddCountryButtonClick(object sender, RoutedEventArgs e) =>
            new PopupWindow(new CountryEditPage()).Show();
        private void ClearPageButtonClick(object sender, RoutedEventArgs e) =>
            NavigationService.Navigate(EditPassport == null ? new PassportEditPage() : new PassportEditPage(EditPassport));
    }
}
