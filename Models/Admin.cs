using System;
using System.Collections.Generic;

namespace TourMgmtApp.Models;

public partial class Admin
{
    public int AdminId { get; set; }

    public int? ALoginid { get; set; }

    public virtual Login? ALogin { get; set; }
}
