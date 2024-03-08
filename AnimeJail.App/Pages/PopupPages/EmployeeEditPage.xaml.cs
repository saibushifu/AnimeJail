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

namespace AnimeJail.App.Pages.PopupPages
{
    /// <summary>
    /// Логика взаимодействия для EmployeeEditPage.xaml
    /// </summary>
    public partial class EmployeeEditPage : Page
    {
        public Employee? EditEmployee { get; set; } = null;
        public EmployeeEditPage()
        {
            BaseCtorConfig();
        }

        public EmployeeEditPage(Employee editEmployee)
        {
            EditEmployee = editEmployee;
            DataContext = this;
            BaseCtorConfig();
        }

        private void BaseCtorConfig()
        {
            InitializeComponent();
            cbWorkPosition.ItemsSource = DataFromDb.WorkPositionCollection;
            cbPassport.ItemsSource = DataFromDb.PassportCollection;
        }

        private void AddEmployeeButtonClick(object sender, RoutedEventArgs e)
        {
            //try
            //{
            //    var newEmployee = new Employee
            //    {
            //        FirstName = tbFirstName.cText,
            //        SecondName = tbSecondName.cText,
            //        Email = tbEmail.cText,
            //        Birthdate = DateOnly.FromDateTime(dpBirthdate.SelectedDate.Value),
            //        Dismdate = dpDismdate != null ? DateOnly.FromDateTime(dpDismdate.SelectedDate.Value) : null,
            //        Hiredate = DateOnly.FromDateTime(dpHiredate.SelectedDate.Value),
            //        MiddleName = tbMiddleName.cText,
            //        PhoneNumber = tbPhoneNumber.cText,
            //        WorkPositionId = Convert.ToInt32(cbWorkPosition.SelectedValue),
            //        PassportId = Convert.ToInt32(cbPassport.SelectedValue)
            //    };
            //    App.Context.Employees.Add(newEmployee);
            //    App.Context.SaveChanges();
            //    DataFromDb.EmployeeCollection.Add(newEmployee);
            //    MessageBox.Show("Операция успешно выполнена!");
            //}
            //catch(Exception ex) { MessageBox.Show(ex.Message); }


            var isEmployeeNull = EditEmployee == null;

            Employee currentEmployee = isEmployeeNull ? new Employee { } : App.Context.Employees.First(x => x.Id == EditEmployee.Id);
            currentEmployee.FirstName = tbFirstName.cText;
            currentEmployee.SecondName = tbSecondName.cText;
            currentEmployee.Email = tbEmail.cText;
            currentEmployee.Birthdate = DateOnly.FromDateTime(dpBirthdate.SelectedDate.Value);
            currentEmployee.Dismdate = dpDismdate != null ? DateOnly.FromDateTime(dpDismdate.SelectedDate.Value) : null;
            currentEmployee.Hiredate = DateOnly.FromDateTime(dpHiredate.SelectedDate.Value);
            currentEmployee.MiddleName = tbMiddleName.cText;
            currentEmployee.PhoneNumber = tbPhoneNumber.cText;
            currentEmployee.WorkPositionId = Convert.ToInt32(cbWorkPosition.SelectedValue);
            currentEmployee.PassportId = Convert.ToInt32(cbPassport.SelectedValue);

            CommonDataFunc<Employee>.AddObjToDb(isEmployeeNull, App.Context.Employees, currentEmployee, DataFromDb.EmployeeCollection,
                isEmployeeNull ? null : DataFromDb.EmployeeCollection.First(x => x.Id == EditEmployee.Id));

        }

        private void AddWorkPositionButtonClick(object sender, RoutedEventArgs e) =>
            new PopupWindow(new WorkPositionEditPage()).Show();

        private void AddPassportButtonClick(object sender, RoutedEventArgs e) =>
            new PopupWindow(new PassportEditPage()).Show();

        private void ClearPageButtonClick(object sender, RoutedEventArgs e) =>
            NavigationService.Navigate(EditEmployee == null ? new EmployeeEditPage() : new EmployeeEditPage(EditEmployee));
    }
}
