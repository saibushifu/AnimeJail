using System;
using System.Collections.Generic;

namespace AnimeJail.App.Models;

public partial class WorkPostion
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
