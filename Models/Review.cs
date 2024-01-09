using System;
using System.Collections.Generic;

namespace TourMgmtApp.Models;

public partial class Review
{
    public int ReviewId { get; set; }

    public int? FOrderid { get; set; }

    public int? Rating { get; set; }

    public string? Feedback { get; set; }
}
