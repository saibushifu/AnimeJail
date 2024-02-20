using AnimeJail.App.Methods;
using AnimeJail.App.Models;
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
            cbJailType.ItemsSource = DataFromDb.JailTypeCollection;
        }
        public PrisonCellEditPage(Jail editJail) : this()
        {
        }

        private void AddJailButtonClick(object sender, RoutedEventArgs e)
        {
            try
            {
                App.Context.Add(new Jail
                {
                    Id = Convert.ToInt32(tbJailNumber.cText),
                    Capacity = Convert.ToInt32(tbCapacity.cText),
                    TypeId = Convert.ToInt32(cbJailType.SelectedValue)
                });
                App.Context.SaveChanges();
                MessageBox.Show("Операция выполнена успешно");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void AddJailTypeButtonClick(object sender, RoutedEventArgs e) =>
            new PopupWindow(new JailTypeEditPage()).Show();
    }
}
