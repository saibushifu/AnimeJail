using System;
using System.Collections.Generic;

namespace AnimeJail.App.Models;

public partial class PassportDatum
{
    public int Id { get; set; }

    public DateOnly IssueDate { get; set; }

    public int? DomiclleRegistrationAdressId { get; set; }

    public int? Serial { get; set; }

    public int Number { get; set; }

    public int IssuingCountryId { get; set; }

    public virtual Address? DomiclleRegistrationAdress { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

    public virtual Country IssuingCountry { get; set; } = null!;

    public virtual ICollection<Prisoner> Prisoners { get; set; } = new List<Prisoner>();
}
