using System;
using System.Collections.Generic;

namespace AnimeJail.App.Models;

public partial class Article
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }
}
