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
    /// Логика взаимодействия для UserEditPage.xaml
    /// </summary>
    public partial class UserEditPage : Page
    {
        public UserEditPage()
        {
            InitializeComponent();
            cbEmployee.ItemsSource = DataFromDb.EmployeeCollection;
        }

        public UserEditPage(User editUser) : this()
        {
        }
        private void AddUserButtonClick(object sender, RoutedEventArgs e)
        {
            try
            {
                string login = tbUsername.cText, password = tbPassword.cText;
                var newUser = new User
                {
                    Login = login,
                    Password = CryptoFunc.QuickHash(password),
                    EmployeeId = Convert.ToInt32(cbEmployee.SelectedValue)
                };
                App.Context.Users.Add(newUser);
                App.Context.SaveChanges();
                DataFromDb.UserCollection.Add(newUser);
                MessageBox.Show("Операция выполнена успешно!");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void AddEmployeeButtonClick(object sender, RoutedEventArgs e) =>
            new PopupWindow(new EmployeeEditPage()).Show();
    }
}
