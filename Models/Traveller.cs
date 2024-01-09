using System;
using System.Collections.Generic;

namespace TourMgmtApp.Models;

public partial class Traveller
{
    public int Travellerid { get; set; }

    public string? Fname { get; set; }

    public string? Lname { get; set; }

    public string? Bdate { get; set; }

    public string? Gender { get; set; }

    public int? Orderid { get; set; }

    public virtual Orderrecord? Order { get; set; }
}
