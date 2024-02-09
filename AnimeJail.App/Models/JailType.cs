using System;
using System.Collections.Generic;

namespace AnimeJail.App.Models;

public partial class JailType
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Jail> Jails { get; set; } = new List<Jail>();
}
