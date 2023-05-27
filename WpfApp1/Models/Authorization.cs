using System;
using System.Collections.Generic;

namespace WpfApp1.Models;

public partial class Authorization
{
    public int Id { get; set; }

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;
}
