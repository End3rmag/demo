using System;
using System.Collections.Generic;

namespace Demo2.Models;

public partial class Categori
{
    public int CategoryId { get; set; }

    public string CategoryName { get; set; } = null!;

    public virtual ICollection<ProductCategori> ProductCategoris { get; set; } = new List<ProductCategori>();
}
