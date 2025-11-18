using System;
using System.Collections.Generic;

namespace CronogramaSenac.Models;

public partial class TurmaUc
{
    public int Id { get; set; }

    public int? CargaHoraria { get; set; }

    public int? UcId { get; set; }

    public int? TurmaId { get; set; }

    public virtual Turma? Turma { get; set; }

    public virtual Uc? Uc { get; set; }
}
