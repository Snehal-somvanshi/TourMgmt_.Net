using System;
using System.Collections.Generic;

namespace TourMgmtApp.Models;

public partial class Transaction
{
    public int TransactionId { get; set; }

    public decimal Amount { get; set; }

    public DateTime? Paymentdate { get; set; }

    public string? Paymenttype { get; set; }

    public virtual ICollection<Orderrecord> Orderrecords { get; set; } = new List<Orderrecord>();
}
