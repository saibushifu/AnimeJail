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
    /// Логика взаимодействия для PrisonerViewPage.xaml
    /// </summary>
    public partial class PrisonerViewPage : Page
    {
        public PrisonerViewPage()
        {
            InitializeComponent();
            dgPrisoner.ItemsSource = DataFromDb.PrisonerCollection;
        }

        private void PrisonerAddButtonClick(object sender, RoutedEventArgs e) =>
            new PopupWindow(new PrisonerEditPage()).Show();

        private void DeletePrisonerButtonClick(object sender, RoutedEventArgs e)
        {
            CommonDataFunc<Prisoner>.DeleteObjFromDb(sender, DataFromDb.PrisonerCollection);
        }

        private void EditPrisonerButtonClick(object sender, RoutedEventArgs e)
        {
            CommonPageFunc.OpenPage(new PrisonerEditPage(CommonDataFunc<Prisoner>.TypeFromSender(sender)));
        }
    }
}
