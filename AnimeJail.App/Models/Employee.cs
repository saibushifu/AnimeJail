using System;
using System.Collections.Generic;

namespace AnimeJail.App.Models;

public partial class Employee
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string SecondName { get; set; } = null!;

    public string? MiddleName { get; set; }

    public int WorkPositionId { get; set; }

    public DateOnly Birthdate { get; set; }

    public string PhoneNumber { get; set; } = null!;

    public string? Email { get; set; }

    public DateOnly Hiredate { get; set; }

    public DateOnly? Dismdate { get; set; }

    public int PassportId { get; set; }

    public virtual PassportDatum Passport { get; set; } = null!;

    public virtual ICollection<User> Users { get; set; } = new List<User>();

    public virtual WorkPostion WorkPosition { get; set; } = null!;
}
