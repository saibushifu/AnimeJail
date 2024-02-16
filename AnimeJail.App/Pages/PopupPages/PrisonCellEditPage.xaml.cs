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
    /// Логика взаимодействия для PrisonCellEditPage.xaml
    /// </summary>
    public partial class PrisonCellEditPage : Page
    {
        public PrisonCellEditPage()
        {
            InitializeComponent();
            cbJailType.ItemsSource = App.Context.JailTypes.ToList();
        }
        public PrisonCellEditPage(Jail editJail) : this()
        {
        }

        private void AddJailButtonClick(object sender, RoutedEventArgs e)
        {

        }
    }
}
