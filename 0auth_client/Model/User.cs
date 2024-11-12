using System;
using System.Collections.Generic;

namespace _0auth_client.Model;

public partial class User
{
    public int IdUser { get; set; }

    public string SurnameUser { get; set; } = null!;

    public string NameUser { get; set; } = null!;

    public string PatronymicUser { get; set; } = null!;

    public string? LoginUser { get; set; }

    public string? PasswordUser { get; set; }

    public int IdRole { get; set; }
}
