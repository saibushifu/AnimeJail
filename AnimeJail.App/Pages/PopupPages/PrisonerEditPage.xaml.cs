using AnimeJail.App.Methods;
using AnimeJail.App.Models;
using AnimeJail.App.Windows;
using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.Xml;
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

namespace AnimeJail.App.Pages.PopupPages;

/// <summary>
/// Логика взаимодействия для PrisonerEditPage.xaml
/// </summary>
public partial class PrisonerEditPage : Page
{
    private byte[] _imageBytes = null;
    public Prisoner? EditPrisoner { get; set; } = null;
    Jail? selectedJail = null;
    public PrisonerEditPage()
    {
        BaseCtorConfig();
    }
    public PrisonerEditPage(Prisoner editPrisoner)
    {
        EditPrisoner = editPrisoner;
        DataContext = this;
        BaseCtorConfig();
    }

    private void BaseCtorConfig()
    {
        InitializeComponent();
        cbAdress.ItemsSource = DataFromDb.AddressCollection;
        cbPassport.ItemsSource = DataFromDb.PassportCollection;
        lst.ItemsSource = App.Context.Articles.ToList();
        UpdateContext();
        foreach (Article article in lst.Items)
        {
            article.IsChecked = IsArticleChecked(article.Id);
        }
    }

    private bool IsArticleChecked(int articleId)
    {
        if (EditPrisoner == null) return false;
        return App.Context.ArticlePrisoners.Any(ap => ap.PrisonerId == EditPrisoner.Id && ap.ArticleId == articleId);
    }


    private void UpdateContext()
    {
        if (EditPrisoner != null) cbBerth.ItemsSource = DataFromDb.BerthCollection.Where(x => (x.Prisoners.Count == 0) || (x.Id == EditPrisoner.BerthId));
        else cbBerth.ItemsSource = DataFromDb.BerthCollection.Where(x => x.Prisoners.Count == 0);
    }

    private void ConvertImage()
    {
        try
        {
            using (MemoryStream stream = new MemoryStream())
            {
                JpegBitmapEncoder encoder = new JpegBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create((BitmapImage)iPrisonerPhoto.Source));
                encoder.Save(stream);
                _imageBytes = stream.ToArray();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Ошибка при конвертации изображения: {ex.Message}");
        }
    }
    private void OpenDialog()
    {
        try
        {
            var dialog = new OpenFileDialog
            {
                CheckFileExists = true,
                Multiselect = false,
                Filter = "Images (*.jpg,*.png)|*.jpg;*.png|All Files(*.*)|*.*"
            };

            if (dialog.ShowDialog() != true) { return; }
            var path = dialog.FileName;
            iPrisonerPhoto.Source = new BitmapImage(new Uri(path));
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Ошибка при выборе изображения: {ex.Message}");
        }
    }


    private void AddPrisonerButtonClick(object sender, RoutedEventArgs e)
    {
        try
        {
            if (iPrisonerPhoto.Source == null)
            {
                MessageBox.Show("Нельзя добавить заключённого без фото!"); return;
            }
            ConvertImage();
            var isPrisonerNull = EditPrisoner == null;

            Prisoner currentPrisoner = isPrisonerNull ? new Prisoner { } : App.Context.Prisoners.First(x => x.Id == EditPrisoner.Id);
            currentPrisoner.FirstName = tbFirstName.cText;
            currentPrisoner.MiddleName = tbMiddleName.cText;
            currentPrisoner.SecondName = tbSecondName.cText;
            currentPrisoner.AddressId = Convert.ToInt32(cbAdress.SelectedValue);
            currentPrisoner.BirthDate = DateOnly.FromDateTime(dpBirthdate.SelectedDate.Value);
            currentPrisoner.FreedomDate = DateOnly.FromDateTime(dpFreedate.SelectedDate.Value);
            currentPrisoner.ImprisonmentDate = DateOnly.FromDateTime(dpIndate.SelectedDate.Value);
            currentPrisoner.PassportId = Convert.ToInt32(cbPassport.SelectedValue);
            currentPrisoner.Image = _imageBytes;
            currentPrisoner.BerthId = Convert.ToInt32(cbBerth.SelectedValue);

            CommonDataFunc<Prisoner>.AddObjToDb(isPrisonerNull, App.Context.Prisoners, currentPrisoner,
                DataFromDb.PrisonerCollection, isPrisonerNull ? null : DataFromDb.PrisonerCollection.First(x => x.Id == EditPrisoner.Id));

            if (EditPrisoner != null)
            {
                var articlesPrisonerList = App.Context.ArticlePrisoners.Where(x => x.PrisonerId == EditPrisoner.Id);
                if (articlesPrisonerList != null)
                {
                    App.Context.RemoveRange(articlesPrisonerList);
                    foreach (var item in articlesPrisonerList) DataFromDb.ArticlePrisonerCollection.Remove(item);
                }
            }

            var articles = ((List<Article>)lst.ItemsSource).Where(x => x.IsChecked);
            var articlesPrisoner = new List<ArticlePrisoner>();
            foreach (var item in articles) articlesPrisoner.Add(new ArticlePrisoner { Article = item, Prisoner = currentPrisoner });
            App.Context.AddRange(articlesPrisoner);
            App.Context.SaveChanges();
            foreach (var item in articlesPrisoner) DataFromDb.ArticlePrisonerCollection.Add(item);

        }
        catch (Exception ex) { MessageBox.Show("Ошибка: " + ex.Message); }
    }

    private void AddPassportButtonClick(object sender, RoutedEventArgs e) =>
        CommonPageFunc.OpenPage(new PassportEditPage());

    private void AddAddressButtonClick(object sender, RoutedEventArgs e) =>
        CommonPageFunc.OpenPage(new AddressEditPage());

    private void bSelectImage_Click(object sender, RoutedEventArgs e)
    {
        OpenDialog();
    }

    private void AddBerthButtonClick(object sender, RoutedEventArgs e)
    {
        //CommonPageFunc.OpenPage(new BerthEditPage());
        new PopupWindow(new BerthEditPage()).ShowDialog();
        UpdateContext();

    }

    private void cbJail_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        UpdateContext();
    }
    private void ClearPageButtonClick(object sender, RoutedEventArgs e) =>
        NavigationService.Navigate(EditPrisoner == null ? new PrisonerEditPage() : new PrisonerEditPage(EditPrisoner));
}
