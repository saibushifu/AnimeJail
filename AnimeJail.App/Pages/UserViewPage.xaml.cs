﻿using AnimeJail.App.Models;
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
    /// Логика взаимодействия для UserViewPage.xaml
    /// </summary>
    public partial class UserViewPage : Page
    {
        public UserViewPage()
        {
            InitializeComponent();
            dgUsers.ItemsSource = App.Context.Users.ToList();
            cbUserType.ItemsSource = App.Context.WorkPostions.ToList();
        }

        private void UserAddButtonClick(object sender, RoutedEventArgs e) =>
             new PopupWindow(new UserEditPage()).Show();
    }
}
