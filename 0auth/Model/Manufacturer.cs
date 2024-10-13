using System;
using System.Collections.Generic;

namespace _0auth.Model;

public partial class Manufacturer
{
    public int IdManufacturer { get; set; }

    public string? NameManufacturer { get; set; }

    public virtual ICollection<Product> Products { get; } = new List<Product>();
}
