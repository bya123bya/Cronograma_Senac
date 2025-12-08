using System;
using System.Collections.Generic;

namespace CronogramaSenac.Models;

public partial class Uc
{
    public int Id { get; set; }

    public DateOnly? DataAula { get; set; }

    public int? QtsAulas { get; set; }

    public TimeOnly? HoraChegada { get; set; }

    public TimeOnly? HoraSaida { get; set; }

    public bool? Lancamento { get; set; }

    public DateOnly? DataInicio { get; set; }

    public DateOnly? DataFim { get; set; }

    public string? Nome { get; set; }

    public virtual ICollection<TurmaUc> TurmaUcs { get; set; } = new List<TurmaUc>();
}
