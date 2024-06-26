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
    /// Логика взаимодействия для WorkPositionViewPage.xaml
    /// </summary>
    public partial class WorkPositionViewPage : Page
    {
        public WorkPositionViewPage()
        {
            InitializeComponent();
            dgWorkPositions.ItemsSource = DataFromDb.WorkPositionCollection;
        }
        private void WorkPositionAddButtonClick(object sender, RoutedEventArgs e) => CommonPageFunc.OpenPage(new WorkPositionEditPage());

        private void DeleteWorkPositionButtonClick(object sender, RoutedEventArgs e)
        {
            CommonDataFunc<WorkPostion>.DeleteObjFromDb(sender, DataFromDb.WorkPositionCollection);
        }

        private void EditWorkPositionButtonClick(object sender, RoutedEventArgs e)
        {
            CommonPageFunc.OpenPage(new WorkPositionEditPage(CommonDataFunc<WorkPostion>.TypeFromSender(sender)));
        }
    }
}
