using System;
using System.Collections.Generic;

namespace ExamenU2.Models;

public partial class AsignacionUsuariosDispositivo
{
    public int UsuarioId { get; set; }

    public int? DispositivoId { get; set; }

    public virtual Dispositivo? Dispositivo { get; set; }

    public virtual Usuario Usuario { get; set; } = null!;
}
