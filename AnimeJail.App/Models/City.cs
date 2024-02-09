using System;
using System.Collections.Generic;

namespace AnimeJail.App.Models;

public partial class City
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? RegionId { get; set; }

    public int CountryId { get; set; }

    public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();

    public virtual Country Country { get; set; } = null!;

    public virtual Region? Region { get; set; }
}
