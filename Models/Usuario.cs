using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ExamenU2.Models;

public partial class Usuario
{
	public int UsuarioId { get; set; }

	[Required(ErrorMessage ="El nombre es obligatorio")]
    [MaxLength(50,ErrorMessage ="Solo se aceptan 50 caracteres")]
    [MinLength(5,ErrorMessage ="Minimo 3 caracteres")]
    [Display(Name="Nombre")] 
	public string NombreUsuario { get; set; } = null!;

	public string Contraseña { get; set; } = null!;

	public int TipoUsuario { get; set; }

	public virtual AsignacionUsuariosDispositivo? AsignacionUsuariosDispositivo { get; set; }

	public virtual Rol TipoUsuarioNavigation { get; set; } = null!;
}
