using System;
using System.Collections.Generic;

namespace WpfApp1.Models;

public partial class Fio
{
    public int Id { get; set; }

    public string Surname { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Patronymic { get; set; } = null!;
}
