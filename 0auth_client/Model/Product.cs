using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace _0auth.Model;

public partial class Product
{
    public string ProductArticleNumber { get; set; } = null!;

    public string NameProduct { get; set; } = null!;

    public string MeasureProduct { get; set; } = null!;

    public decimal CostProduct { get; set; }

    public string? DescriptionProduct { get; set; }

    public int IdProductType { get; set; }

    public string? PhotoProduct { get; set; }
    [NotMapped]
    public string DisplayedPhoto => $"/Resources/{PhotoProduct = (PhotoProduct == null ? "picture.png" : PhotoProduct)}";

    public int IdSupplier { get; set; }

    public int? MaxDiscount { get; set; }

    public int IdManufacturer { get; set; }

    public int? CurrentDiscount { get; set; }

    public string StatusProduct { get; set; } = null!;

    public int QuantityInStock { get; set; }
    public virtual Supplier IdSupplierNavigation { get; set; } = null!;
    public virtual ProductType IdProductTypeNavigation { get; set; } = null!;
    public virtual Manufacturer IdManufacturerNavigation { get; set; } = null!;

}
