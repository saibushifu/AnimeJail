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
    /// Логика взаимодействия для WorkPositionViewPage.xaml
    /// </summary>
    public partial class WorkPositionViewPage : Page
    {
        public WorkPositionViewPage()
        {
            InitializeComponent();
            dgWorkPositions.ItemsSource = DataFromDb.WorkPositionCollection;
        }

        public WorkPositionViewPage(WorkPostion editWorkPositon) : this()
        {
        }

        private void WorkPositionAddButtonClick(object sender, RoutedEventArgs e) => 
            new PopupWindow(new WorkPositionEditPage()).ShowDialog();
    }
}
