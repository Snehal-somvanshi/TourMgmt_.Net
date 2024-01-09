using System;
using System.Collections.Generic;

namespace TourMgmtApp.Models;

public partial class Address
{
    public int AddressId { get; set; }

    public string? Addressline { get; set; }

    public string? District { get; set; }

    public string? City { get; set; }

    public int? PostalCode { get; set; }

    public string? State { get; set; }

    public string? Country { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

    public virtual ICollection<Tourist> Tourists { get; set; } = new List<Tourist>();
}
