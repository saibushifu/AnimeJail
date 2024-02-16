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
    /// Логика взаимодействия для PrisonerEditPage.xaml
    /// </summary>
    public partial class PrisonerEditPage : Page
    {
        public PrisonerEditPage()
        {
            InitializeComponent();
            cbAdress.ItemsSource = App.Context.Addresses.ToList();
            cbPassport.ItemsSource = App.Context.PassportData.ToList();
        }
        public PrisonerEditPage(Prisoner editPrisoner) : this()
        {
        }

        private void AddPrisonerButtonClick(object sender, RoutedEventArgs e)
        {
            try
            {
                App.Context.Add(new Prisoner
                {
                    FirstName = tbFirstName.cText,
                    MiddleName = tbMiddleName.cText,
                    SecondName = tbSecondName.cText,
                    Address = cbAdress.SelectedValue as Address,
                    BirthDate = DateOnly.FromDateTime(dpBirthdate.SelectedDate.Value),
                    FreedomDate = DateOnly.FromDateTime(dpFreedate.SelectedDate.Value),
                    ImprisonmentDate = DateOnly.FromDateTime(dpIndate.SelectedDate.Value),
                    Passport = cbPassport.SelectedValue as PassportDatum,
                    //Photo 
 });

                App.Context.SaveChanges();
                MessageBox.Show("Операция выполнена успешно");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}
