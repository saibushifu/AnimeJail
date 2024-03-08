using AnimeJail.App.Methods;
using AnimeJail.App.Models;
using AnimeJail.App.Windows;
using Npgsql.Internal.Postgres;
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
using System.Xml.Linq;

namespace AnimeJail.App.Pages.PopupPages
{
    /// <summary>
    /// Логика взаимодействия для PrisonCellEditPage.xaml
    /// </summary>
    public partial class PrisonCellEditPage : Page
    {
        public Jail? EditJail { get; set; } = null;
        public PrisonCellEditPage()
        {
            BaseCtorConfig();
        }
        public PrisonCellEditPage(Jail editJail)
        {
            EditJail = editJail;
            DataContext = this;
            BaseCtorConfig();
        }

        private void BaseCtorConfig()
        {
            InitializeComponent();
            cbJailType.ItemsSource = DataFromDb.JailTypeCollection;
        }

        private void AddJailButtonClick(object sender, RoutedEventArgs e)
        {
            //try
            //{
            //    var newJail = new Jail
            //    {
            //        Id = Convert.ToInt32(tbJailNumber.cText),
            //        Capacity = Convert.ToInt32(tbCapacity.cText),
            //        TypeId = Convert.ToInt32(cbJailType.SelectedValue)
            //    };
            //    App.Context.Add(newJail);
            //    App.Context.SaveChanges();
            //    DataFromDb.JailCollection.Add(newJail);
            //    MessageBox.Show("Операция выполнена успешно");
            //}
            //catch (Exception ex) { MessageBox.Show(ex.Message); }

            var isJailNull = EditJail == null;

            Jail currentArticle = isJailNull ? new Jail { } : App.Context.Jails.First(x => x.Id == EditJail.Id);
            currentArticle.Id = Convert.ToInt32(tbJailNumber.cText);
            currentArticle.Capacity = Convert.ToInt32(tbCapacity.cText);
            currentArticle.TypeId = Convert.ToInt32(cbJailType.SelectedValue);

            CommonDataFunc<Jail>.AddObjToDb(isJailNull, App.Context.Jails, currentArticle, DataFromDb.JailCollection,
                isJailNull ? null : DataFromDb.JailCollection.First(x => x.Id == EditJail.Id));
        }

        private void AddJailTypeButtonClick(object sender, RoutedEventArgs e) =>
            new PopupWindow(new JailTypeEditPage()).Show();
        private void ClearPageButtonClick(object sender, RoutedEventArgs e) =>
            NavigationService.Navigate(EditJail == null ? new PrisonCellEditPage() : new PrisonCellEditPage(EditJail));
    }
}
