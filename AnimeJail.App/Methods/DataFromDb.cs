using AnimeJail.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeJail.App.Methods
{
    public class DataFromDb
    {
        public static List<Country> GetCountryList()
        {
            var countryList = App.Context.Countries.ToList();
            countryList.Insert(0, new Country { Id = 0, Name = "Все" });
            return countryList;
        }
        public static List<Region> GetRegionList()
        {
            var regionList = App.Context.Regions.ToList();
            regionList.Insert(0, new Region { Id = 0, CountryId = 0, Name = "Все" });
            return regionList;
        }

        public static List<City> GetCityList()
        {
            var cityList = App.Context.Cities.ToList();
            cityList.Insert(0, new City { Id = 0, Name = "Все", CountryId = 0 });
            return cityList;
        }



    }
}
