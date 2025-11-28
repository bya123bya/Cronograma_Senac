using System;
using System.Collections.Generic;

namespace CronogramaSenac.Models;

public partial class Usuario
{
    public int Id { get; set; }

    public string? Nome { get; set; }

    public string? Email { get; set; }

    public string? Senha { get; set; }

    public int? TipoUsuarioId { get; set; }

    public virtual ICollection<Falta> Falta { get; set; } = new List<Falta>();

    public virtual TipoUsuario? TipoUsuario { get; set; }

    public virtual ICollection<UsuarioTurma> UsuarioTurmas { get; set; } = new List<UsuarioTurma>();
}

