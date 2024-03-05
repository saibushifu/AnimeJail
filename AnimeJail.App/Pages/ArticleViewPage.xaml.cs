using AnimeJail.App.Methods;
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
    /// Логика взаимодействия для ArticleViewPage.xaml
    /// </summary>
    public partial class ArticleViewPage : Page
    {
        public ArticleViewPage()
        {
            InitializeComponent();
            dgArticle.ItemsSource = DataFromDb.ArticleCollection;
        }

        private void ArticleAddButtonClick(object sender, RoutedEventArgs e) =>
            new PopupWindow(new ArticleEditPage()).Show();
        private void ListUpdate()
        {

        }

        private void DeleteArticleButtonClick(object sender, RoutedEventArgs e)
        {
            CommonDataFunc<Article>.DeleteObjFromDb(sender, DataFromDb.ArticleCollection);
        }

        private void EditArticleButtonClick(object sender, RoutedEventArgs e)
        {

        }
    }
}
