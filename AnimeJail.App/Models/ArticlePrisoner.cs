using System;
using System.Collections.Generic;

namespace AnimeJail.App.Models;

public partial class ArticlePrisoner
{
    public int PrisonerId { get; set; }

    public int ArticleId { get; set; }

    public bool? IsActual { get; set; }

    public virtual Article Article { get; set; } = null!;

    public virtual Prisoner Prisoner { get; set; } = null!;
}
