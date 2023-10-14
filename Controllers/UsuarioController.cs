using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ExamenU2.Models;
using ExamenU2.Views.Usuario;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ExamenU2.Controllers
{
	public class UsuarioController : Controller
	{
		public readonly  ControlConsumoAguaContext db; //Mapear el contexto

		public UsuarioController(ControlConsumoAguaContext db)
		{
			this.db = db;
		}
		[HttpGet]
		public IActionResult Login()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Login(Usuario usuario, string? url)
		{
			  // Buscar un usuario en la base de datos que coincida con el correo electrónico y la contraseña proporcionados
			Usuario u = db.Usuarios.Include(x => x.TipoUsuarioNavigation).FirstOrDefault(x => x.NombreUsuario == usuario.NombreUsuario && x.Contraseña == usuario.Contraseña);
			// Si no se encuentra ningún usuario, agregar un error al modelo y devolver la vista con el usuario nulo
			if (u == null)
			{
				ModelState.AddModelError("NombreUsuario", "Usuario y/o password incorrectos");
				return View(u);
			}
			 // Si el modelo es válido, proceder con el inicio de sesión
			// if (ModelState.IsValid)
			// {
				// Crear una lista de reclamaciones (claims) para el usuario
				List<Claim> claims = new List<Claim>();
				// Agregar reclamaciones al nombre de usuario, autenticación, rol y identificador de nombre
				claims.Add(new Claim("username", u.NombreUsuario));
				claims.Add(new Claim(ClaimTypes.Authentication, u.UsuarioId + ""));
				claims.Add(new Claim(ClaimTypes.Role, u.TipoUsuarioNavigation.Rol1));
				// Crear una identidad de reclamaciones (claims) basada en el esquema de autenticación de cookies
				ClaimsIdentity identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
				// Crear un principal de reclamaciones (claims) basado en la identidad
				ClaimsPrincipal principal = new ClaimsPrincipal(identity);
				// Iniciar sesión en el contexto actual utilizando el principal de reclamaciones (claims)
				await HttpContext.SignInAsync(principal);
				// Redireccionar al método "Tablero" del controlador "Home"
				return RedirectToAction("Tablero", "Home");
		//	}
			// Redireccionar al método "Login"
			//return RedirectToAction("Login");
		}
		
		[Authorize]
		public async Task<IActionResult> CerrarSesion()
		{
			// Cerrar la sesión actual, eliminando las cookies de autenticación
			await HttpContext.SignOutAsync();
			// Redireccionar al método "IniciarSesion"
			return RedirectToAction("Login");
		}
		
		public IActionResult CrearCuenta()
		{
			return View();
		}
		[HttpPost]
		public IActionResult CrearCuenta(Usuario usuario)
		{
			try
			{
				usuario.TipoUsuario = 2;//Se le asigna el id del rol 4 de encargado
				db.Usuarios.Add(usuario);
				db.SaveChanges();//se fuarda la informacion en la base de datos
				return RedirectToAction("Tablero", "Home");//Si se registra correctamente, se manda a la vista del tablero
			}
			catch (System.Exception ex)
			{
				return RedirectToAction("AlgoSalioMal", "Errores");//En caso de error, se manda a la pagina de algo salio mal.
			}
		}
		
		
	}
}