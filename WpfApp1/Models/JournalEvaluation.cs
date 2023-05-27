using System;
using System.Collections.Generic;

namespace WpfApp1.Models;

public partial class JournalEvaluation
{
    public int Id { get; set; }

    public string? Surname { get; set; }

    public string? Name { get; set; }

    public string? Patronymic { get; set; }

    public int? Evaluation { get; set; }

    public string? Gruppa { get; set; }
}
