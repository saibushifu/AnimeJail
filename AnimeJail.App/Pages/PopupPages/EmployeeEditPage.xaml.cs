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
    /// Логика взаимодействия для EmployeeEditPage.xaml
    /// </summary>
    public partial class EmployeeEditPage : Page
    {
        public EmployeeEditPage()
        {
            InitializeComponent();
            cbWorkPosition.ItemsSource = App.Context.WorkPostions.ToList();
            cbPassport.ItemsSource = App.Context.PassportData.ToList();
        }

        public EmployeeEditPage(Employee editEmployee) : this()
        {
        }

        private void AddEmployeeButtonClick(object sender, RoutedEventArgs e)
        {
            try
            {
                App.Context.Employees.Add(new Employee {FirstName = tbFirstName.cText, SecondName = tbSecondName.cText, Email = tbEmail.cText, 
                    Birthdate = DateOnly.FromDateTime(dpBirthdate.SelectedDate.Value), Dismdate = dpDismdate != null ? DateOnly.FromDateTime(dpDismdate.SelectedDate.Value) : null, 
                    Hiredate = DateOnly.FromDateTime(dpHiredate.SelectedDate.Value), MiddleName = tbMiddleName.cText, PhoneNumber = tbPhoneNumber.cText,
                    WorkPositionId  = Convert.ToInt32(cbWorkPosition.SelectedValue), PassportId = Convert.ToInt32(cbPassport.SelectedValue)
                });
                App.Context.SaveChanges();
                MessageBox.Show("Операция успешно выполнена!");
            }
            catch(Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}
