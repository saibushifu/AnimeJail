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
    /// Логика взаимодействия для IconButton.xaml
    /// </summary>
    public partial class IconButton : UserControl
    {
        public PathGeometry BtnIcon { get; set; }
        public IconButton()
        {
            InitializeComponent();
            DataContext = this;
        }
    }
}
