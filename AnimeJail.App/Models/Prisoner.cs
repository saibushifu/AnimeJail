using System;
using System.Collections;
using System.Collections.Generic;

namespace AnimeJail.App.Models;

public partial class Prisoner
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string SecondName { get; set; } = null!;

    public string? MiddleName { get; set; }

    public DateOnly? BirthDate { get; set; }

    public DateOnly ImprisonmentDate { get; set; }

    public DateOnly FreedomDate { get; set; }

    public int AddressId { get; set; }

    public int PassportId { get; set; }

    public BitArray? Photo { get; set; }

    public virtual Address Address { get; set; } = null!;

    public virtual PassportDatum Passport { get; set; } = null!;
}
