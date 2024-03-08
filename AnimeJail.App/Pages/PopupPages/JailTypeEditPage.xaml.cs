using AnimeJail.App.Methods;
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
    /// Логика взаимодействия для JailTypeEditPage.xaml
    /// </summary>
    public partial class JailTypeEditPage : Page
    {
        public JailType? EditJailType { get; set; } = null;
        public JailTypeEditPage()
        {
            InitializeComponent();
        }

        public JailTypeEditPage(JailType editJailType)
        {
            EditJailType = editJailType;
            DataContext = this;
            InitializeComponent();
        }

        private void AddJailTypeButtonClick(object sender, RoutedEventArgs e)
        {
            //try
            //{
            //    var newJail = new JailType { 
            //        Id = Convert.ToInt32(tbId.cText), 
            //        Name = tbName.cText };
            //    App.Context.Add(newJail);
            //    App.Context.SaveChanges();
            //    DataFromDb.JailTypeCollection.Add(newJail);
            //    MessageBox.Show("Операция выполнена успешно");
            //}
            //catch (Exception ex) { MessageBox.Show(ex.Message); }

            var isJailTypeNull = EditJailType == null;

            JailType currentJailType = isJailTypeNull ? new JailType { } : App.Context.JailTypes.First(x => x.Id == EditJailType.Id);
            currentJailType.Id = Convert.ToInt32(tbId.cText);
            currentJailType.Name = tbName.cText;

            CommonDataFunc<JailType>.AddObjToDb(isJailTypeNull, App.Context.JailTypes, currentJailType, DataFromDb.JailTypeCollection,
                isJailTypeNull ? null : DataFromDb.JailTypeCollection.First(x => x.Id == EditJailType.Id));

        }
        private void ClearPageButtonClick(object sender, RoutedEventArgs e) =>
            NavigationService.Navigate(EditJailType == null ? new JailTypeEditPage() : new JailTypeEditPage(EditJailType));
    }
}
