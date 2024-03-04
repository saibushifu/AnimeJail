﻿using AnimeJail.App.Methods;
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
    /// Логика взаимодействия для WorkPositionEditPage.xaml
    /// </summary>
    public partial class WorkPositionEditPage : Page
    {
        public WorkPositionEditPage()
        {
            InitializeComponent();
        }


        public WorkPositionEditPage(WorkPostion editWorkPosition) : this()
        { 
        }
        private void AddWorkPositionButtonClick(object sender, RoutedEventArgs e)
        {
            try
            {
                var newWorkPosition = new WorkPostion { Id = Convert.ToInt32(tbId.cText), Name = tbName.cText };
                App.Context.WorkPostions.Add(newWorkPosition);
                App.Context.SaveChanges();
                DataFromDb.WorkPositionCollection.Add(newWorkPosition);
                MessageBox.Show("Сохранение произведено успешно!");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}
