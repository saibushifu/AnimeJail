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
        Prisoner prisoner = null;
        Jail? selectedJail = null;
        public PrisonerEditPage()
        {
            InitializeComponent();
            cbAdress.ItemsSource = DataFromDb.AddressCollection;
            cbPassport.ItemsSource = DataFromDb.PassportCollection;
            cbJail.ItemsSource = DataFromDb.JailCollection.Where(x => x.Capacity > DataFromDb.JailPrisonerCollection.Count(y => y.JailId == x.Id));
            UpdateContext();
        }
        public PrisonerEditPage(Prisoner editPrisoner) : this()
        {
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
                if (iPrisonerPhoto != null) { ConvertImage(); }
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
                var newJailPrisoner = new JailPrisoner { JailId = (cbJail.SelectedValue as Jail).Id, PrisonerId = newPrisoner.Id, BerthId = Convert.ToInt32(cbBerth.SelectedValue) };
                App.Context.Add(newJailPrisoner);
                App.Context.SaveChanges();
                DataFromDb.PrisonerCollection.Add(newPrisoner);
                DataFromDb.JailPrisonerCollection.Add(newJailPrisoner);
                MessageBox.Show("Операция выполнена успешно");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void AddPassportButtonClick(object sender, RoutedEventArgs e) =>
            new PopupWindow(new PassportEditPage()).Show();

        private void AddAddressButtonClick(object sender, RoutedEventArgs e) =>
            new PopupWindow(new AddressEditPage()).Show();

        private void bSelectImage_Click(object sender, RoutedEventArgs e)
        {
            OpenDialog();
        }

        private void AddJailButtonClick(object sender, RoutedEventArgs e) =>
            new PopupWindow(new PrisonCellEditPage()).Show();

        private void cbJail_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateContext();
        }
    }
}
