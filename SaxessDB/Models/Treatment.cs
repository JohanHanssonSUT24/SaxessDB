using System;
using System.Collections.Generic;

namespace SaxessDB.Models;

public partial class Treatment
{
    public int Id { get; set; }

    public string? Type { get; set; }

    public decimal? Price { get; set; }

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    public virtual ICollection<EmployeeTreatment> EmployeeTreatments { get; set; } = new List<EmployeeTreatment>();
}
