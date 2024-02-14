﻿using AnimeJail.App.Models;
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
    /// Логика взаимодействия для CityEditPage.xaml
    /// </summary>
    public partial class CityEditPage : Page
    {
        public CityEditPage()
        {
            InitializeComponent();
            cbCountry.ItemsSource = App.Context.Countries.ToList();
            cbRegion.ItemsSource = App.Context.Regions.ToList();
        }

        public CityEditPage(City editCity) : this()
        {

        }

        private void AddCityButtonClick(object sender, RoutedEventArgs e)
        {

        }
    }
}
