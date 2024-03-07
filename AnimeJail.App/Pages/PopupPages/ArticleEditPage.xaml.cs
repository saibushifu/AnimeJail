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
    /// Логика взаимодействия для ArticleEditPage.xaml
    /// </summary>
    public partial class ArticleEditPage : Page
    {
        private Article? EditArticle = null;
        public ArticleEditPage()
        {
            InitializeComponent();
        }
        public ArticleEditPage(Article editArticle) : this()
        {
            EditArticle = editArticle;
        }

        private void AddArticleButtonClick(object sender, RoutedEventArgs e)
        {
            try
            {
                var newArticle = new Article
                {
                    Id = Convert.ToInt32(tbId.cText),
                    Description = tbDescription.cText,
                    Name = tbName.cText
                };
                App.Context.Add(newArticle);
                App.Context.SaveChanges();
                DataFromDb.ArticleCollection.Add(newArticle);
                MessageBox.Show("Операция выполнена успешно");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void ClearPageButtonClick(object sender, RoutedEventArgs e) =>
             NavigationService.Navigate(EditArticle == null ? new ArticleEditPage() : new ArticleEditPage(EditArticle));
    }
}
