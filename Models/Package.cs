using System;
using System.Collections.Generic;

namespace TourMgmtApp.Models;

public partial class Package
{
    public int PackageId { get; set; }

    public string? Packagename { get; set; }

    public int TouristCapacity { get; set; }

    public string Description { get; set; } = null!;

    public string? Locations { get; set; }

    public string? Boardinglocation { get; set; }

    public string? Duration { get; set; }

    public virtual ICollection<Packageimage> Packageimages { get; set; } = new List<Packageimage>();

    public virtual ICollection<Plannedtour> Plannedtours { get; set; } = new List<Plannedtour>();
}
