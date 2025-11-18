using System;
using System.Collections.Generic;

namespace CronogramaSenac.Models;

public partial class Uc
{
    public int Id { get; set; }

    public string? Nome { get; set; }

    public string? Descrição { get; set; }

    public virtual ICollection<TurmaUc> TurmaUcs { get; set; } = new List<TurmaUc>();
}
