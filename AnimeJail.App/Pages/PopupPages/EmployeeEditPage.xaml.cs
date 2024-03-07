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
    /// Логика взаимодействия для EmployeeEditPage.xaml
    /// </summary>
    public partial class EmployeeEditPage : Page
    {
        private Employee? EditEmployee = null;
        public EmployeeEditPage()
        {
            InitializeComponent();
            cbWorkPosition.ItemsSource = DataFromDb.WorkPositionCollection;
            cbPassport.ItemsSource = DataFromDb.PassportCollection;
        }

        public EmployeeEditPage(Employee editEmployee) : this()
        {
            EditEmployee = editEmployee;
        }

        private void AddEmployeeButtonClick(object sender, RoutedEventArgs e)
        {
            try
            {
                var newEmployee = new Employee
                {
                    FirstName = tbFirstName.cText,
                    SecondName = tbSecondName.cText,
                    Email = tbEmail.cText,
                    Birthdate = DateOnly.FromDateTime(dpBirthdate.SelectedDate.Value),
                    Dismdate = dpDismdate != null ? DateOnly.FromDateTime(dpDismdate.SelectedDate.Value) : null,
                    Hiredate = DateOnly.FromDateTime(dpHiredate.SelectedDate.Value),
                    MiddleName = tbMiddleName.cText,
                    PhoneNumber = tbPhoneNumber.cText,
                    WorkPositionId = Convert.ToInt32(cbWorkPosition.SelectedValue),
                    PassportId = Convert.ToInt32(cbPassport.SelectedValue)
                };
                App.Context.Employees.Add(newEmployee);
                App.Context.SaveChanges();
                DataFromDb.EmployeeCollection.Add(newEmployee);
                MessageBox.Show("Операция успешно выполнена!");
            }
            catch(Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void AddWorkPositionButtonClick(object sender, RoutedEventArgs e) =>
            new PopupWindow(new WorkPositionEditPage()).Show();

        private void AddPassportButtonClick(object sender, RoutedEventArgs e) =>
            new PopupWindow(new PassportEditPage()).Show();

        private void ClearPageButtonClick(object sender, RoutedEventArgs e) =>
            NavigationService.Navigate(EditEmployee == null ? new EmployeeEditPage() : new EmployeeEditPage(EditEmployee));
    }
}
