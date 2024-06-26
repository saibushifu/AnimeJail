﻿using AnimeJail.App.Methods;
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
    /// Логика взаимодействия для PassportViewPage.xaml
    /// </summary>
    public partial class PassportViewPage : Page
    {
        public PassportViewPage()
        {
            InitializeComponent();
            dgPassport.ItemsSource = DataFromDb.PassportCollection;
        }

        private void PassoprtAddButtonClick(object sender, RoutedEventArgs e) =>
            new PopupWindow(new PassportEditPage()).Show();

        private void DeletePassportButtonClick(object sender, RoutedEventArgs e)
        {
            CommonDataFunc<PassportDatum>.DeleteObjFromDb(sender, DataFromDb.PassportCollection);
        }

        private void EditPassportButtonClick(object sender, RoutedEventArgs e)
        {
            CommonPageFunc.OpenPage(new PassportEditPage(CommonDataFunc<PassportDatum>.TypeFromSender(sender)));
        }
    }
}
