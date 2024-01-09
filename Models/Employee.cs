using System;
using System.Collections.Generic;

namespace TourMgmtApp.Models;

public partial class Employee
{
    public int EmployeeId { get; set; }

    public string EBdate { get; set; } = null!;

    public string EFname { get; set; } = null!;

    public string? EMname { get; set; }

    public string? ELname { get; set; }

    public DateOnly EHiredate { get; set; }

    public string EDesignation { get; set; } = null!;

    public string EContact { get; set; } = null!;

    public int? EAddressid { get; set; }

    public string? EAdharno { get; set; }

    public byte[]? EPhoto { get; set; }

    public int? ELoginid { get; set; }

    public string? EEmail { get; set; }

    public string? EGender { get; set; }

    public virtual Address? EAddress { get; set; }

    public virtual Login? ELogin { get; set; }

    public virtual ICollection<Plannedtour> Plannedtours { get; set; } = new List<Plannedtour>();
}
