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
    /// Логика взаимодействия для PassportEditPage.xaml
    /// </summary>
    public partial class PassportEditPage : Page
    {
        public PassportEditPage()
        {
            InitializeComponent();
        }

        public PassportEditPage(PassportDatum editPassport) : this()
        {
        }

        private void AddPassportButtonClick(object sender, RoutedEventArgs e)
        {

        }
    }
}
