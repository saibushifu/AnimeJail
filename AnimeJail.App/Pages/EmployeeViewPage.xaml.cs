using AnimeJail.App.Methods;
using AnimeJail.App.Models;
using AnimeJail.App.Pages.PopupPages;
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

namespace AnimeJail.App.Pages
{
    /// <summary>
    /// Логика взаимодействия для EmployeeViewPage.xaml
    /// </summary>
    public partial class EmployeeViewPage : Page
    {
        public EmployeeViewPage()
        {
            InitializeComponent();
            dgEmployee.ItemsSource = DataFromDb.EmployeeCollection;
            cbWorkPosition.ItemsSource = DataFromDb.WorkPositionCollection;
            cbIsWorker.ItemsSource = new List<string> { "Работает", "Уволен" };
        }

        private void EmployeeAddButtonClick(object sender, RoutedEventArgs e) =>
            new PopupWindow(new EmployeeEditPage()).Show();

        private void ListUpdate()
        {

        }
    }
}
