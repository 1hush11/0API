using System;
using System.Collections.Generic;

namespace _0auth.Model;

public partial class Point
{
    public int IdPoint { get; set; }

    public int? PostCode { get; set; }

    public string? AddressPoint { get; set; }

    public virtual ICollection<Order> Orders { get; } = new List<Order>();
}
