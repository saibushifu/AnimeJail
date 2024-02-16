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
    /// Логика взаимодействия для PrisonerEditPage.xaml
    /// </summary>
    public partial class PrisonerEditPage : Page
    {
        public PrisonerEditPage()
        {
            InitializeComponent();
            cbAdress.ItemsSource = App.Context.Addresses.ToList();
            cbPassport.ItemsSource = App.Context.PassportData.ToList();
        }
        public PrisonerEditPage(Prisoner editPrisoner) : this()
        {
        }

        private void AddPrisonerButtonClick(object sender, RoutedEventArgs e)
        {

        }
    }
}
