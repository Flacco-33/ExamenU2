using System;
using System.Collections.Generic;

namespace ExamenU2.Models;

public partial class RegistrosConsumo
{
    public int RegistroId { get; set; }

    public int? DispositivoId { get; set; }

    public DateTime FechaHoraInicio { get; set; }

    public DateTime FechaHoraFin { get; set; }

    public decimal LitrosRegistrados { get; set; }

    public virtual Dispositivo? Dispositivo { get; set; }
}
