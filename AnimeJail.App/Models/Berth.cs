using System;
using System.Collections.Generic;

namespace AnimeJail.App.Models;

public partial class Berth
{
    public string Id { get; set; } = null!;

    public int? JailId { get; set; }

    public virtual Jail? Jail { get; set; }

    public virtual ICollection<Prisoner> Prisoners { get; set; } = new List<Prisoner>();
}
