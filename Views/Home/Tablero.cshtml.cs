using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace ExamenU2.Views.Home
{
    public class Tablero : PageModel
    {
        private readonly ILogger<Tablero> _logger;

        public Tablero(ILogger<Tablero> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}