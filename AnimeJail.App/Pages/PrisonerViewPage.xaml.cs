using AnimeJail.App.Methods;
using AnimeJail.App.Models;
using AnimeJail.App.Pages.PopupPages;
using AnimeJail.App.Windows;
using System.Windows;
using System.Windows.Controls;

namespace AnimeJail.App.Pages;

/// <summary>
/// Логика взаимодействия для PrisonerViewPage.xaml
/// </summary>
public partial class PrisonerViewPage : Page
{
    public PrisonerViewPage()
    {
        InitializeComponent();
        dgPrisoner.ItemsSource = DataFromDb.PrisonerCollection;
    }

    private void PrisonerAddButtonClick(object sender, RoutedEventArgs e) =>
        new PopupWindow(new PrisonerEditPage()).Show();

    private void DeletePrisonerButtonClick(object sender, RoutedEventArgs e)
    {
        var prisonerId = ((Prisoner)((Button)sender).DataContext).Id;
        var articlePrisoner = App.Context.ArticlePrisoners.Where(x => x.PrisonerId == prisonerId);
        if (articlePrisoner != null) App.Context.ArticlePrisoners.RemoveRange(articlePrisoner);
        CommonDataFunc<Prisoner>.DeleteObjFromDb(sender, DataFromDb.PrisonerCollection);
    }

    private void EditPrisonerButtonClick(object sender, RoutedEventArgs e)
    {
        new PopupWindow(new PrisonerEditPage((Prisoner)((Button)sender).DataContext)).ShowDialog();
        dgPrisoner.Items.Refresh();
    }
}
