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
        public PrisonerEditPage()
        {
            InitializeComponent();
            cbAdress.ItemsSource = DataFromDb.AddressCollection;
            cbPassport.ItemsSource = DataFromDb.PassportCollection;
        }
        public PrisonerEditPage(Prisoner editPrisoner) : this()
        {
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
                    Photo = _imageBytes == null ? null : new BitArray(_imageBytes)
                };
                App.Context.Add(newPrisoner);
                App.Context.SaveChanges();
                DataFromDb.PrisonerCollection.Add(newPrisoner);
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
    }
}
