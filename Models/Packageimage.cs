using System;
using System.Collections.Generic;

namespace TourMgmtApp.Models;

public partial class Packageimage
{
    public int PackageimageId { get; set; }

    public byte[]? Packimage { get; set; }

    public int? PackageId { get; set; }

    public virtual Package? Package { get; set; }
}
