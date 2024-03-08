using AnimeJail.App.Methods;
using AnimeJail.App.Models;
using AnimeJail.App.Windows;
using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
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
            cbJail.ItemsSource = DataFromDb.JailCollection.Where(x => x.Capacity > DataFromDb.JailPrisonerCollection.Count(y => y.JailId == x.Id));
            UpdateContext();
        }


        private void UpdateContext()
        {
            selectedJail = cbJail.SelectedValue as Jail;
            var berths = Enumerable.Range(1, (int)selectedJail.Capacity);
            cbBerth.ItemsSource = berths.Except(DataFromDb.JailPrisonerCollection.Where(x => x.JailId == selectedJail.Id).Select(x => x.BerthId));
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
                if (iPrisonerPhoto.Source != null) { ConvertImage(); }
                var newPrisoner = new Prisoner
                {
                    FirstName = tbFirstName.cText,
                    MiddleName = tbMiddleName.cText,
                    SecondName = tbSecondName.cText,
                    AddressId = Convert.ToInt32(cbAdress.SelectedValue),
                    BirthDate = DateOnly.FromDateTime(dpBirthdate.SelectedDate.Value),
                    FreedomDate = DateOnly.FromDateTime(dpFreedate.SelectedDate.Value),
                    ImprisonmentDate = DateOnly.FromDateTime(dpIndate.SelectedDate.Value),
                    PassportId = Convert.ToInt32(cbPassport.SelectedValue),
                    Image = _imageBytes == null ? null : _imageBytes
                };
                App.Context.Add(newPrisoner);
                var newJailPrisoner = new JailPrisoner { JailId = (cbJail.SelectedValue as Jail).Id, Prisoner = newPrisoner, BerthId = Convert.ToInt32(cbBerth.SelectedValue) };
                App.Context.Add(newJailPrisoner);
                var selectedArticles = (List<Article>)lst.ItemsSource;
                var articles = selectedArticles.Where(x => x.IsChecked);
                var articlesPrisoner = new List<ArticlePrisoner>();
                foreach (var item in articles) articlesPrisoner.Add(new ArticlePrisoner { Article = item, Prisoner = newPrisoner });
                App.Context.AddRange(articlesPrisoner);
                App.Context.SaveChanges();
                DataFromDb.PrisonerCollection.Add(newPrisoner);
                DataFromDb.JailPrisonerCollection.Add(newJailPrisoner);
                foreach (var item in articlesPrisoner) DataFromDb.ArticlePrisonerCollection.Add(item);
                MessageBox.Show("Операция выполнена успешно");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }





        }

        private void AddPassportButtonClick(object sender, RoutedEventArgs e) =>
            CommonPageFunc.OpenPage(new PassportEditPage());

        private void AddAddressButtonClick(object sender, RoutedEventArgs e) =>
            CommonPageFunc.OpenPage(new AddressEditPage());

        private void bSelectImage_Click(object sender, RoutedEventArgs e)
        {
            OpenDialog();
        }

        private void AddJailButtonClick(object sender, RoutedEventArgs e) =>
            CommonPageFunc.OpenPage(new PrisonCellEditPage());

        private void cbJail_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateContext();
        }
        private void ClearPageButtonClick(object sender, RoutedEventArgs e) =>
            NavigationService.Navigate(EditPrisoner == null ? new PrisonerEditPage() : new PrisonerEditPage(EditPrisoner));
    }
}
