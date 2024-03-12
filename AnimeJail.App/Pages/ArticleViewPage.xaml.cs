using AnimeJail.App.Methods;
using AnimeJail.App.Models;
using AnimeJail.App.Pages.PopupPages;
using AnimeJail.App.Windows;
using System.Windows;
using System.Windows.Controls;

namespace AnimeJail.App.Pages;

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

    private void ArticleAddButtonClick(object sender, RoutedEventArgs e) => new PopupWindow(new ArticleEditPage()).Show();
    private void DeleteArticleButtonClick(object sender, RoutedEventArgs e) => CommonDataFunc<Article>.DeleteObjFromDb(sender, DataFromDb.ArticleCollection);
    private void EditArticleButtonClick(object sender, RoutedEventArgs e) => 
        CommonPageFunc.OpenPage(new ArticleEditPage(CommonDataFunc<Article>.TypeFromSender(sender)));
}
