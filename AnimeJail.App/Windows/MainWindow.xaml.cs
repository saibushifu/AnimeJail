using AnimeJail.App.Pages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
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

namespace AnimeJail.App.Windows
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            PagesNavigation.Navigate(new EmptyPage());
        }

        private void PrisonCellButtonClick(object sender, RoutedEventArgs e) =>
            PagesNavigation.Navigate(new PrisonCellViewPage());
        

        private void PrisonerButtonClick(object sender, RoutedEventArgs e) =>
            PagesNavigation.Navigate(new PrisonerViewPage());

        private void EmployeeButtonClick(object sender, RoutedEventArgs e) =>
            PagesNavigation.Navigate(new EmployeeViewPage());

        private void ArticleButtonClick(object sender, RoutedEventArgs e) =>
            PagesNavigation.Navigate(new ArticleViewPage());

        private void AddressButtonClick(object sender, RoutedEventArgs e) =>
            PagesNavigation.Navigate(new AddressViewPage());

        private void PassportButtonClick(object sender, RoutedEventArgs e) =>
            PagesNavigation.Navigate(new PassportViewPage());

        private void UserButtonClick(object sender, RoutedEventArgs e) =>
            PagesNavigation.Navigate(new UserViewPage());
    }
}
