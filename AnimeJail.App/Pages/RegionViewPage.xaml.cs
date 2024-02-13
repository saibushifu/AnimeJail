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
    /// Логика взаимодействия для RegionViewPage.xaml
    /// </summary>
    public partial class RegionViewPage : Page
    {
        public RegionViewPage()
        {
            InitializeComponent();
            dgRegion.ItemsSource = App.Context.Regions.ToList();

        }

        private void RegionAddButtonClick(object sender, RoutedEventArgs e) =>
             new PopupWindow(new RegionEditPage()).Show();
    }
}
