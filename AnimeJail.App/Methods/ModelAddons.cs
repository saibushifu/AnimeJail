using AnimeJail.App.Data;
using AnimeJail.App.Methods;
using Microsoft.EntityFrameworkCore;
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

public partial class Prisoner
{
    [NotMapped]
    public JailPrisoner? DisplayBerth => DataFromDb.JailPrisonerCollection.FirstOrDefault(x => x.PrisonerId == this.Id);

    [NotMapped]
    public JailPrisoner? DisplayJail => DataFromDb.JailPrisonerCollection.FirstOrDefault(x => x.PrisonerId == this.Id);

    [NotMapped]
    public string? AllArticles => string.Concat(DataFromDb.ArticlePrisonerCollection.Where(x => x.PrisonerId == this.Id).Select(x => x.ArticleId.ToString() + " "));
}

public partial class Article
{
    [NotMapped]
    public string DisplayName => this.Id + " " + this.Name;

    [NotMapped]
    public bool IsChecked { get; set; } =  false;
}

public class TrueContext : SharpProjectsContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["LocalConnectionString"].ConnectionString;
        optionsBuilder.UseNpgsql(connectionString);
    }
}