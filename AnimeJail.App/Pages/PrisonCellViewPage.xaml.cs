﻿using AnimeJail.App.Pages.PopupPages;
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
    /// Логика взаимодействия для PrisonCellViewPage.xaml
    /// </summary>
    public partial class PrisonCellViewPage : Page
    {
        public PrisonCellViewPage()
        {
            InitializeComponent();
        }

        private void PrisonCellAddButtonClick(object sender, RoutedEventArgs e) =>
            new PopupWindow(new PrisonCellEditPage()).Show();
    }
}
