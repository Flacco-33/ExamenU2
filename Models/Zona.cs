using System;
using System.Collections.Generic;

namespace ExamenU2.Models;

public partial class Zona
{
    public int ZonaId { get; set; }

    public string NombreZona { get; set; } = null!;

    public virtual ICollection<Dispositivo> Dispositivos { get; set; } = new List<Dispositivo>();
}
