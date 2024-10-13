using System;
using System.Collections.Generic;

namespace _0auth.Model;

public partial class ProductType
{
    public int IdProductType { get; set; }

    public string? NameProductType { get; set; }

    public virtual ICollection<Product> Products { get; } = new List<Product>();
}
