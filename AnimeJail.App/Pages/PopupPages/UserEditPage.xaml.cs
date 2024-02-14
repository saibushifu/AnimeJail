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
    /// Логика взаимодействия для UserEditPage.xaml
    /// </summary>
    public partial class UserEditPage : Page
    {
        public UserEditPage()
        {
            InitializeComponent();
            cbEmployee.ItemsSource = App.Context.Employees.ToList();
        }

        public UserEditPage(User editUser) : this()
        {
        }
        private void AddUserButtonClick(object sender, RoutedEventArgs e)
        {
            try
            {
                string login = tbUsername.cText, password = tbPassword.cText;
                App.Context.Users.Add(new User { Login = login, Password = CryptoFunc.QuickHash(password), EmployeeId = Convert.ToInt32(cbEmployee.SelectedValue) });
                App.Context.SaveChanges();
                MessageBox.Show("Операция выполнена успешно!");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}
