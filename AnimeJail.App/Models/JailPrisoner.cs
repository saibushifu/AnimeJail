using System;
using System.Collections.Generic;

namespace AnimeJail.App.Models;

public partial class JailPrisoner
{
    public int JailId { get; set; }

    public int BerthId { get; set; }

    public int PrisonerId { get; set; }

    public virtual Prisoner Prisoner { get; set; } = null!;
}
