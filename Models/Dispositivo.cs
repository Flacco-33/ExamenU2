using System;
using System.Collections.Generic;

namespace ExamenU2.Models;

public partial class Dispositivo
{
    public int DispositivoId { get; set; }

    public string Identificador { get; set; } = null!;

    public string DireccionMac { get; set; } = null!;

    public decimal Latitud { get; set; }

    public decimal Longitud { get; set; }

    public string? Descripcion { get; set; }

    public int? Prioridad { get; set; }

    public bool? Estatus { get; set; }

    public string? NombreResponsable { get; set; }

    public int Zona { get; set; }

    public virtual ICollection<AsignacionUsuariosDispositivo> AsignacionUsuariosDispositivos { get; set; } = new List<AsignacionUsuariosDispositivo>();

    public virtual ICollection<RegistrosConsumo> RegistrosConsumos { get; set; } = new List<RegistrosConsumo>();

    public virtual Zona ZonaNavigation { get; set; } = null!;
}
