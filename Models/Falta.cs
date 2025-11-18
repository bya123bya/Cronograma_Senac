using System;
using System.Collections.Generic;

namespace CronogramaSenac.Models;

public partial class Falta
{
    public int Id { get; set; }

    public DateOnly? Dia { get; set; }

    public string? Justificado { get; set; }

    public int? UsuarioId { get; set; }

    public int? TurmaId { get; set; }

    public virtual Turma? Turma { get; set; }

    public virtual Usuario? Usuario { get; set; }
}
