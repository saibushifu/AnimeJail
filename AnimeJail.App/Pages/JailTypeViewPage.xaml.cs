using AnimeJail.App.Methods;
using AnimeJail.App.Models;
using AnimeJail.App.Pages.PopupPages;
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

namespace AnimeJail.App.Pages;

/// <summary>
/// Логика взаимодействия для JailTypeViewPage.xaml
/// </summary>
public partial class JailTypeViewPage : Page
{
    public JailTypeViewPage()
    {
        InitializeComponent();
        dgJailType.ItemsSource = DataFromDb.JailTypeCollection;
    }


    private void DeleteJailTypeButtonClick(object sender, RoutedEventArgs e) => CommonDataFunc<JailType>.DeleteObjFromDb(sender, DataFromDb.JailTypeCollection);
    private void EditJailTypeButtonClick(object sender, RoutedEventArgs e) => CommonPageFunc.OpenPage(new JailTypeEditPage(CommonDataFunc<JailType>.TypeFromSender(sender)));
    private void JailTypeButtonClick(object sender, RoutedEventArgs e) => CommonPageFunc.OpenPage(new JailTypeEditPage());
}
