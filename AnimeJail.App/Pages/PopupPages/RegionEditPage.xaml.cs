using AnimeJail.App.Methods;
using AnimeJail.App.Models;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace AnimeJail.App.Pages.PopupPages;

/// <summary>
/// Логика взаимодействия для RegionEditPage.xaml
/// </summary>
public partial class RegionEditPage : Page
{
    public Region? EditRegion { get; set; } = null;
    public RegionEditPage()
    {
        BaseCtorConfig();
    }
    public RegionEditPage(Region editRegion)
    {
        EditRegion = editRegion;
        DataContext = this;
        BaseCtorConfig();
    }

    private void BaseCtorConfig()
    {
        InitializeComponent();
        cbCountry.ItemsSource = DataFromDb.CountryCollection;

        if (EditRegion != null) cbCountry.SelectedValue = EditRegion.CountryId;
    }

    private void AddRegionButtonClick(object sender, RoutedEventArgs e)
    {
        var isRegionNull = EditRegion == null;

        Region currentRegion = isRegionNull ? new Region { } : App.Context.Regions.First(x => x.Id == EditRegion.Id);
        currentRegion.Id = Convert.ToInt32(tbId.cText);
        currentRegion.CountryId = Convert.ToInt32(cbCountry.SelectedValue);
        currentRegion.Name = tbName.cText;

        CommonDataFunc<Region>.AddObjToDb(isRegionNull, App.Context.Regions, currentRegion, DataFromDb.RegionsCollection,
            isRegionNull ? null : DataFromDb.RegionsCollection.First(x => x.Id == EditRegion.Id));
    }

    private void AddCountryButtonClick(object sender, RoutedEventArgs e) => CommonPageFunc.OpenPage(new CountryEditPage());

    private void ClearPageButtonClick(object sender, RoutedEventArgs e) =>
        NavigationService.Navigate(EditRegion == null ? new RegionEditPage() : new RegionEditPage(EditRegion));
}
