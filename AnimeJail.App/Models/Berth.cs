using System;
using System.Collections.Generic;

namespace AnimeJail.App.Models;

public partial class Berth
{
    public int? JailId { get; set; }

    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual Jail? Jail { get; set; }

    public virtual ICollection<Prisoner> Prisoners { get; set; } = new List<Prisoner>();
}
