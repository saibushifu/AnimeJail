using System;
using System.Collections.Generic;

namespace AnimeJail.App.Models;

public partial class Country
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<City> Cities { get; set; } = new List<City>();

    public virtual ICollection<PassportDatum> PassportData { get; set; } = new List<PassportDatum>();

    public virtual ICollection<Region> Regions { get; set; } = new List<Region>();
}
