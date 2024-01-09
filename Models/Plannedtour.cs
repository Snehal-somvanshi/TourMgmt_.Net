using System;
using System.Collections.Generic;

namespace TourMgmtApp.Models;

public partial class Plannedtour
{
    public int TourId { get; set; }

    public DateOnly? Startdate { get; set; }

    public DateOnly? Lastdate { get; set; }

    public int? Availseats { get; set; }

    public DateOnly? LastdateApply { get; set; }

    public int? Packageid { get; set; }

    public int? Employeeid { get; set; }

    public int? Status { get; set; }

    public double? Packageprice { get; set; }

    public virtual Employee? Employee { get; set; }

    public virtual ICollection<Orderrecord> Orderrecords { get; set; } = new List<Orderrecord>();

    public virtual Package? Package { get; set; }
}
