using System;
using System.Collections.Generic;

namespace CronogramaSenac.Models;

public partial class UsuarioTurma
{
    public int Id { get; set; }

    public string? Nome { get; set; }

    public int? UsuarioId { get; set; }

    public int? TurmaId { get; set; }

    public virtual Turma? Turma { get; set; }

    public virtual Usuario? Usuario { get; set; }
}
