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
    /// Логика взаимодействия для EmployeeMenuPage.xaml
    /// </summary>
    public partial class EmployeeMenuPage : Page
    {
        public EmployeeMenuPage()
        {
            InitializeComponent();
        }

        private void EmployeeButtonClick(object sender, RoutedEventArgs e) =>
            NavigationService.Navigate(new EmployeeViewPage());
        private void WorkPositionButtonClick(object sender, RoutedEventArgs e) =>
            NavigationService.Navigate(new WorkPositionViewPage());
    }
}
