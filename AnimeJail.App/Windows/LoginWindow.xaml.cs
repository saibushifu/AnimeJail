using AnimeJail.App.Methods;
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
            //var ld = new LoginData(tbUsername.cText, tbPassword.PassBox.Password);
            //if (ld.TryLogin())
            //{
            //    new MainWindow().Show();
            //    this.Hide();
            //}
            //else
            //{
            //    MessageBox.Show("Ошибка входа!\nПроверьте правильность введённых данных.", "Внмание", MessageBoxButton.OK, MessageBoxImage.Warning);
            //}
            new MainWindow().Show();
            this.Hide();
        }
    }
}
