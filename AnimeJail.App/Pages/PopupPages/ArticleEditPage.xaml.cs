using AnimeJail.App.Methods;
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
        public Article? EditArticle { get; set; } = null;
        public ArticleEditPage()
        {
            InitializeComponent();
        }
        public ArticleEditPage(Article editArticle)
        {
            EditArticle = editArticle;
            DataContext = this;
            InitializeComponent();
        }

        private void AddArticleButtonClick(object sender, RoutedEventArgs e)
        {
            var isArticleNull = EditArticle == null;

            Article currentArticle = isArticleNull ? new Article { } : App.Context.Articles.First(x => x.Id == EditArticle.Id);
            currentArticle.Id = Convert.ToInt32(tbId.cText);
            currentArticle.Description = tbDescription.cText;
            currentArticle.Name = tbName.cText;

            CommonDataFunc<Article>.AddObjToDb(isArticleNull, App.Context.Articles, currentArticle, DataFromDb.ArticleCollection, 
                isArticleNull ? null : DataFromDb.ArticleCollection.First(x => x.Id == EditArticle.Id));
        }

        private void ClearPageButtonClick(object sender, RoutedEventArgs e) =>
             NavigationService.Navigate(EditArticle == null ? new ArticleEditPage() : new ArticleEditPage(EditArticle));
    }
}
