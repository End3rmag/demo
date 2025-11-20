using System;
using System.Collections.Generic;

namespace Demo2.Models;

public partial class User
{
    public int UserId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public DateTime? RegistDate { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
