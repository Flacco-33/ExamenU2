using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace ExamenU2.Views.Usuario
{
    public class CrearCuenta : PageModel
    {
        private readonly ILogger<CrearCuenta> _logger;

        public CrearCuenta(ILogger<CrearCuenta> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}