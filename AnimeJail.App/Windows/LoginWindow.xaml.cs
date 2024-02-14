using AnimeJail.App.Methods;
using AnimeJail.App.Models;
using System.Windows;

namespace AnimeJail.App.Windows
{
    /// <summary>
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {

            //var user = new LoginData(tbUsername.cText, tbPassword.PassBox.Password).TryLogin();
            //if (user != null)
            //{
            //    new MainWindow(user).Show();
            //    this.Hide();
            //}
            //else
            //{
            //    MessageBox.Show("Ошибка входа!\nПроверьте правильность введённых данных.", "Внмание", MessageBoxButton.OK, MessageBoxImage.Warning);
            //}
            //new MainWindow().Show();
            new MainWindow(new User{}).Show();
            this.Hide();
        }
    }
}
