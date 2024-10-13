using System;
using System.Collections.Generic;

namespace _0auth.Model;

public partial class Order
{
    public int IdOrder { get; set; }

    public DateTime? DispatchDate { get; set; }

    public DateTime DeliveryDate { get; set; }

    public int IdPoint { get; set; }

    public int? IdUser { get; set; }

    public int? CodeOrder { get; set; }

    public int IdOrderStatus { get; set; }

    public virtual OrderStatus IdOrderStatusNavigation { get; set; } = null!;

    public virtual Point IdPointNavigation { get; set; } = null!;

    public virtual User? IdUserNavigation { get; set; }

    public virtual ICollection<OrderProduct> OrderProducts { get; } = new List<OrderProduct>();
}
