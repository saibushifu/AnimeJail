using AnimeJail.App.Models;
using System.Collections.ObjectModel;

namespace AnimeJail.App.Methods;
public class DataFromDb
{
    public static ObservableCollection<Country> CountryCollection = new ObservableCollection<Country>(App.Context.Countries);
    public static ObservableCollection<City> CitiesCollection = new ObservableCollection<City>(App.Context.Cities);
    public static ObservableCollection<Region> RegionsCollection = new ObservableCollection<Region>(App.Context.Regions);
    public static ObservableCollection<PassportDatum> PassportCollection = new ObservableCollection<PassportDatum>(App.Context.PassportData);
    public static ObservableCollection<WorkPostion> WorkPositionCollection = new ObservableCollection<WorkPostion>(App.Context.WorkPostions);
    public static ObservableCollection<Address> AddressCollection = new ObservableCollection<Address>(App.Context.Addresses);
    public static ObservableCollection<JailType> JailTypeCollection = new ObservableCollection<JailType>(App.Context.JailTypes);
    public static ObservableCollection<Employee> EmployeeCollection = new ObservableCollection<Employee>(App.Context.Employees);
    public static ObservableCollection<Article> ArticleCollection = new ObservableCollection<Article>(App.Context.Articles);
    public static ObservableCollection<Jail> JailCollection = new ObservableCollection<Jail>(App.Context.Jails);
    public static ObservableCollection<Prisoner> PrisonerCollection = new ObservableCollection<Prisoner>(App.Context.Prisoners);
    public static ObservableCollection<User> UserCollection = new ObservableCollection<User>(App.Context.Users);
    public static ObservableCollection<ArticlePrisoner> ArticlePrisonerCollection = new ObservableCollection<ArticlePrisoner>(App.Context.ArticlePrisoners);
    public static ObservableCollection<Berth> BerthCollection = new ObservableCollection<Berth>(App.Context.Berths);
}