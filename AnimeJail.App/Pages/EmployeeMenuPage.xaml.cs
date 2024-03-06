using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace AnimeJail.App.Pages;

/// <summary>
/// Логика взаимодействия для EmployeeMenuPage.xaml
/// </summary>
public partial class EmployeeMenuPage : Page
{
    public EmployeeMenuPage() => InitializeComponent();

    private void EmployeeButtonClick(object sender, RoutedEventArgs e) => NavigationService.Navigate(new EmployeeViewPage());
    private void WorkPositionButtonClick(object sender, RoutedEventArgs e) => NavigationService.Navigate(new WorkPositionViewPage());
}