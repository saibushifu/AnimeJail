using System;
using System.Collections.Generic;

namespace AnimeJail.App.Models;

public partial class Address
{
    public int Id { get; set; }

    public int CityId { get; set; }

    public string StreetName { get; set; } = null!;

    public string? BuildingNumber { get; set; }

    public string? ApartmentNumber { get; set; }

    public virtual City City { get; set; } = null!;

    public virtual ICollection<PassportDatum> PassportData { get; set; } = new List<PassportDatum>();

    public virtual ICollection<Prisoner> Prisoners { get; set; } = new List<Prisoner>();
}
