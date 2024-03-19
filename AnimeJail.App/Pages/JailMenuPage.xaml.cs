using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace AnimeJail.App.Pages;

/// <summary>
/// Логика взаимодействия для JailMenuPage.xaml
/// </summary>
public partial class JailMenuPage : Page
{
    public JailMenuPage() => InitializeComponent();
    private void BerthButtonClick(object sender, RoutedEventArgs e) => NavigationService.Navigate(new BerthViewPage());
    private void JailButtonClick(object sender, RoutedEventArgs e) => NavigationService.Navigate(new PrisonCellViewPage());

    private void JailTypeButtonClick(object sender, RoutedEventArgs e) => NavigationService.Navigate(new JailTypeViewPage());
}
