using System;
using System.Collections.Generic;

namespace _0auth.Model;

public partial class User
{
    public int IdUser { get; set; }

    public string SurnameUser { get; set; } = null!;

    public string NameUser { get; set; } = null!;

    public string PatronymicUser { get; set; } = null!;

    public string? LoginUser { get; set; }

    public string? PasswordUser { get; set; }

    public int IdRole { get; set; }

    public virtual Role IdRoleNavigation { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; } = new List<Order>();
}
