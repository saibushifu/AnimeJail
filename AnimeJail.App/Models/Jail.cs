using System;
using System.Collections.Generic;

namespace AnimeJail.App.Models;

public partial class Jail
{
    public int Id { get; set; }

    public int? Capacity { get; set; }

    public int TypeId { get; set; }

    public virtual JailType Type { get; set; } = null!;
}
