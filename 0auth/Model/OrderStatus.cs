using System;
using System.Collections.Generic;

namespace _0auth.Model;

public partial class OrderStatus
{
    public int IdOrderStatus { get; set; }

    public string? NameOrderStatus { get; set; }

    public virtual ICollection<Order> Orders { get; } = new List<Order>();
}
