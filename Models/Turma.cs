using System;
using System.Collections.Generic;

namespace CronogramaSenac.Models;

public partial class Turma
{
    public int Id { get; set; }

    public string? Nome { get; set; }

    public string? Descrição { get; set; }

    public virtual ICollection<DiasTurma> DiasTurmas { get; set; } = new List<DiasTurma>();

    public virtual ICollection<Falta> Falta { get; set; } = new List<Falta>();

    public virtual ICollection<TurmaUc> TurmaUcs { get; set; } = new List<TurmaUc>();

    public virtual ICollection<UsuarioTurma> UsuarioTurmas { get; set; } = new List<UsuarioTurma>();
}
