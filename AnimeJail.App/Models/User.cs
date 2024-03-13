using System;
using System.Collections.Generic;

namespace AnimeJail.App.Models;

public partial class User
{
    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int EmployeeId { get; set; }

    public int Id { get; set; }

    public virtual Employee Employee { get; set; } = null!;
}
