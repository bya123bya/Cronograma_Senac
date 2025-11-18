using System;
using System.Collections.Generic;

namespace CronogramaSenac.Models;

public partial class DiasTurma
{
    public int Id { get; set; }

    public int? DiasSemanaId { get; set; }

    public int? TurmaId { get; set; }

    public virtual DiasSemana? DiasSemana { get; set; }

    public virtual Turma? Turma { get; set; }
}
