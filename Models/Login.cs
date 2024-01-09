using System;
using System.Collections.Generic;

namespace TourMgmtApp.Models;

public partial class Login
{
    public int LoginId { get; set; }

    public string Uid { get; set; } = null!;

    public string Pwd { get; set; } = null!;

    public int? RoleId { get; set; }

    public int Status { get; set; }

    public virtual ICollection<Admin> Admins { get; set; } = new List<Admin>();

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

    public virtual Role? Role { get; set; }

    public virtual ICollection<Tourist> Tourists { get; set; } = new List<Tourist>();
}
