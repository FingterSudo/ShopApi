using System;
using System.Collections.Generic;

namespace ShopApi.Models;

public partial class UserLogin
{
    public int Id { get; set; }

    public string? UserName { get; set; }

    public byte[]? PasswordHash { get; set; }

    public byte[]? PasswordSalt { get; set; }

    public byte[]? RefreshToken { get; set; }

    public DateTime? TokenCreated { get; set; }

    public DateTime? TokenExpires { get; set; }
}
