using System;
using System.Collections.Generic;

namespace TourMgmtApp.Models;

public partial class Orderrecord
{
    public int OrderId { get; set; }

    public int? Touristid { get; set; }

    public int? Tourid { get; set; }

    public int? Travellernumber { get; set; }

    public int? Transactionid { get; set; }

    public virtual Plannedtour? Tour { get; set; }

    public virtual Tourist? Tourist { get; set; }

    public virtual Transaction? Transaction { get; set; }

    public virtual ICollection<Traveller> Travellers { get; set; } = new List<Traveller>();
}
