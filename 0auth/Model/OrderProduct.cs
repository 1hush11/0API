using System;
using System.Collections.Generic;

namespace _0auth.Model;

public partial class OrderProduct
{
    public string IdOrderProduct { get; set; } = null!;

    public int IdOrder { get; set; }

    public string ProductArticleNumber { get; set; } = null!;

    public int Count { get; set; }

    public virtual Order IdOrderNavigation { get; set; } = null!;

    public virtual Product ProductArticleNumberNavigation { get; set; } = null!;
}
