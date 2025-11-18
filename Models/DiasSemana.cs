using System;
using System.Collections.Generic;

namespace CronogramaSenac.Models;

public partial class DiasSemana
{
    public int Id { get; set; }

    public string? Dia { get; set; }

    public virtual ICollection<DiasTurma> DiasTurmas { get; set; } = new List<DiasTurma>();
}
