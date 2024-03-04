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
        public JailTypeEditPage()
        {
            InitializeComponent();
        }

        public JailTypeEditPage(JailType editJailType) : this()
        {
        }

        private void AddJailTypeButtonClick(object sender, RoutedEventArgs e)
        {
            try
            {
                var newJail = new JailType { Id = Convert.ToInt32(tbId.cText), Name = tbName.cText };
                App.Context.Add(newJail);
                App.Context.SaveChanges();
                DataFromDb.JailTypeCollection.Add(newJail);
                MessageBox.Show("Операция выполнена успешно");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}
