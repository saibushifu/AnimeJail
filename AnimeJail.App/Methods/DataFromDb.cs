using AnimeJail.App.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeJail.App.Methods
{
    public class DataFromDb
    {
        public static ObservableCollection<Country> CountryCollection = new ObservableCollection<Country>(App.Context.Countries);
        public static ObservableCollection<City> CitiesColliction = new ObservableCollection<City>(App.Context.Cities);
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


        //public static List<Country> GetCountryList()
        //{
        //    var countryList = App.Context.Countries.ToList();
        //    countryList.Insert(0, new Country { Id = 0, Name = "Все" });
        //    return countryList;
        //}
        //public static List<Region> GetRegionList()
        //{
        //    var regionList = App.Context.Regions.ToList();
        //    regionList.Insert(0, new Region { Id = 0, CountryId = 0, Name = "Все" });
        //    return regionList;
        //}

        //public static List<City> GetCityList()
        //{
        //    var cityList = App.Context.Cities.ToList();
        //    cityList.Insert(0, new City { Id = 0, Name = "Все", CountryId = 0 });
        //    return cityList;
        //}



    }
}
