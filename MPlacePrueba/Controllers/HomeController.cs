using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MPlacePrueba.General;
using MPlacePrueba.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MPlacePrueba.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public delegate String MiDelegado(int numero);
        public HomeController(ILogger<HomeController> logger)
        {
         
            _logger = logger;
        }

        public IActionResult Index()
        {
            int numero = 4;
            Delegado delegado = new Delegado();
            MiDelegado miDelegadoString = new MiDelegado(delegado.DelegadoDevuelveString);
            MiDelegado miDelegadoSigno = new MiDelegado(delegado.DelegadoDevuelveSigno);
            ViewBag.respuesta = $"El numero que envio es {numero} => {miDelegadoString(numero)} y el Signo {miDelegadoSigno(numero)}";


            List<PersonaViewModel> listaPersonas = new List<PersonaViewModel>() {
                new PersonaViewModel() {Nombre = "Taylor",Apellido = "Gomez", Genero= "M", NumeroDocumento = "11283475964"  },
                new PersonaViewModel() {Nombre = "Nicolas",Apellido = "Arrubla", Genero= "M", NumeroDocumento = "11524252343"  },
                new PersonaViewModel() {Nombre = "Olga",Apellido = "Betancur", Genero= "F", NumeroDocumento = "11276216561"  },
                new PersonaViewModel() {Nombre = "Lina",Apellido = "Rojas", Genero= "F", NumeroDocumento = "116721621"  }
            };

            var personasFemeninas = listaPersonas.FindAll(delegate (PersonaViewModel persona) { return persona.Genero == "F"; });
            ViewBag.PersonasFemeninas = personasFemeninas;

            MiDelegado miDelegadoOperacion = new MiDelegado(delegado.RealizarOperacionParImpar);
            ViewBag.ResultadoOperacion = $"El numero que envio es {numero} => {miDelegadoOperacion(numero)}";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
