using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeJail.App.Models;

public partial class Address
{
        [NotMapped]
        public string DisplayName => this.City.Country.Name + " " +
        (this.City.Region == null ? "" : this.City.Region.Name) + " " + this.City.Name + " " +
        this.StreetName + " " + this.BuildingNumber + " " + this.ApartmentNumber;
}

public partial class PassportDatum
{
    [NotMapped]
    public string DisplayName => this.Serial + " " + this.Number;
}

public partial class Employee
{
    [NotMapped]
    public string DisplayName => this.SecondName + " " + this.FirstName + " " + this.MiddleName;
}
