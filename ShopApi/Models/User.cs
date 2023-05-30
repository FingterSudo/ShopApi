using System;
using System.Collections.Generic;

namespace ShopApi.Models;

public partial class User
{
    public int Id { get; set; }

    public string? UserName { get; set; }

    public byte[] PasswordHash { get; set; } = null!;

    public byte[] PasswordSalt { get; set; } = null!;

    public byte[]? RefreshToken { get; set; }

    public DateTime TokenCreated { get; set; }

    public DateTime TokenExpires { get; set; }
}
