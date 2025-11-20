using System;
using System.Collections.Generic;

namespace Demo2.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public string ProductName { get; set; } = null!;

    public string? Discrip { get; set; }

    public decimal Price { get; set; }

    public decimal? MidRating { get; set; }

    public int? DrandId { get; set; }

    public int UserId { get; set; }

    public DateTime? CreatedDate { get; set; }

    public virtual ICollection<ProductCategori> ProductCategoris { get; set; } = new List<ProductCategori>();

    public virtual User User { get; set; } = null!;
}
