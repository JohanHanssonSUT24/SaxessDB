using System;
using System.Collections.Generic;

namespace SaxessDB.Models;

public partial class EmployeeTreatment
{
    public int Id { get; set; }

    public int? EmployeeId { get; set; }

    public int? TreatmentId { get; set; }

    public virtual Employee? Employee { get; set; }

    public virtual Treatment? Treatment { get; set; }
}
