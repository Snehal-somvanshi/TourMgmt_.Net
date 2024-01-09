using System;
using System.Collections.Generic;

namespace TourMgmtApp.Models;

public partial class Tourist
{
    public int TouristId { get; set; }

    public string TFname { get; set; } = null!;

    public string? TLname { get; set; }

    public string? TEmail { get; set; }

    public int? TAddressid { get; set; }

    public string? TContact { get; set; }

    public int? TLoginid { get; set; }

    public DateOnly? TBdate { get; set; }

    public virtual ICollection<Orderrecord> Orderrecords { get; set; } = new List<Orderrecord>();

    public virtual Address? TAddress { get; set; }

    public virtual Login? TLogin { get; set; }
}
