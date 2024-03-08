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
    /// Логика взаимодействия для UserEditPage.xaml
    /// </summary>
    public partial class UserEditPage : Page
    {
        public User? EditUser { get; set; } = null;
        public UserEditPage()
        {
            BaseCtorConfig();
        }
        public UserEditPage(User editUser)
        {
            EditUser = editUser;
            DataContext = this;
            BaseCtorConfig();
        }

        private void BaseCtorConfig()
        {
            InitializeComponent();
            cbEmployee.ItemsSource = DataFromDb.EmployeeCollection;
        }

        private void AddUserButtonClick(object sender, RoutedEventArgs e)
        {
            //try
            //{
            //    string login = tbUsername.cText, password = tbPassword.cText;
            //    var newUser = new User
            //    {
            //        Login = login,
            //        Password = CryptoFunc.QuickHash(password),
            //        EmployeeId = Convert.ToInt32(cbEmployee.SelectedValue)
            //    };
            //    App.Context.Users.Add(newUser);
            //    App.Context.SaveChanges();
            //    DataFromDb.UserCollection.Add(newUser);
            //    MessageBox.Show("Операция выполнена успешно!");
            //}
            //catch (Exception ex) { MessageBox.Show(ex.Message); }

            var isUserNull = EditUser == null;

            User currentUser = isUserNull ? new User { } : App.Context.Users.First(x => x.Id == EditUser.Id);
            string login = tbUsername.cText, password = tbPassword.cText;
            currentUser.Login = login;
            currentUser.Password = CryptoFunc.QuickHash(password);
            currentUser.EmployeeId = Convert.ToInt32(cbEmployee.SelectedValue);

            CommonDataFunc<User>.AddObjToDb(isUserNull, App.Context.Users, currentUser, DataFromDb.UserCollection,
                isUserNull ? null : DataFromDb.UserCollection.First(x => x.Id == EditUser.Id));
        }

        private void AddEmployeeButtonClick(object sender, RoutedEventArgs e) =>
            new PopupWindow(new EmployeeEditPage()).Show();

        private void ClearPageButtonClick(object sender, RoutedEventArgs e) =>
            NavigationService.Navigate(EditUser == null ? new UserEditPage() : new UserEditPage(EditUser));
    }
}
