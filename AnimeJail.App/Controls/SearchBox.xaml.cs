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

namespace AnimeJail.App.Controls
{
    /// <summary>
    /// Логика взаимодействия для SearchBox.xaml
    /// </summary>
    public partial class SearchBox : UserControl
    {
        public SearchBox()
        {
            InitializeComponent();
        }
        private void SearchBorder_LostKeyboardFocus(object sender, System.Windows.Input.KeyboardFocusChangedEventArgs e)
        {
            if (SearchItemTxt.Text == "") LblSearchTxt.Visibility = Visibility.Visible;
        }

        private void SearchBorder_GotKeyboardFocus(object sender, System.Windows.Input.KeyboardFocusChangedEventArgs e) =>
            LblSearchTxt.Visibility = Visibility.Hidden;

    }
}
