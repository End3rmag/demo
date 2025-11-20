using System;
using System.Collections.Generic;

namespace Demo2.Models;

public partial class ProductCategori
{
    public int ProductCategoriId { get; set; }

    public int ProductId { get; set; }

    public int CategoryId { get; set; }

    public virtual Categori Category { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
