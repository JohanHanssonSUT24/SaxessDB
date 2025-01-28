using System;
using System.Collections.Generic;

namespace SaxessDB.Models;

public partial class Customer
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public DateOnly? DoB { get; set; }

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();
}
