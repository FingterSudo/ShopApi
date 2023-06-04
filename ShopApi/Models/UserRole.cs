using System;
using System.Collections.Generic;

namespace ShopApi.Models;

public partial class UserRole
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public string? Roles { get; set; }

    public virtual UserLogin User { get; set; } = null!;
}
