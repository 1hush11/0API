using System;
using System.Collections.Generic;

namespace _0auth.Model;

public partial class Supplier
{
    public int IdSupplier { get; set; }

    public string? NameSupplier { get; set; }

    public virtual ICollection<Product> Products { get; } = new List<Product>();
}
