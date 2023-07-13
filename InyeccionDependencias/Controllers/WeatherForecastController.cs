using InyeccionDependencias.Logica;
using InyeccionDependencias.Logica.Interface;
using InyeccionDependencias.Entidades.Modelo;
using InyeccionDependencias.Repositorio.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

namespace InyeccionDependencias.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly ILProducto _lProducto;
        private readonly IRProducto _rProducto;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, ILProducto iLProducto, IRProducto rProducto)
        {
            _logger = logger;
            _lProducto = iLProducto;
            _rProducto = rProducto;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet("ConsultarProductosInyeccion")]
        public IEnumerable<Producto> ConsultarProductos()
        {
            return _lProducto.ConsultarProductos();
        }

        [HttpPost("IngresarProducto")]
        public IActionResult IngresarProducto(Producto producto)
        {
            return Ok(_lProducto.IngresarProducto(producto));
        }

        [HttpPut("ActualizarProducto")]
        public IActionResult ActualizarProducto(Producto producto)
        {
            return Ok(_lProducto.ActualizarProducto(producto));
        }

        [HttpDelete("EliminarProducto")]
        public JsonResult EliminarProducto(int idProducto)
        {
            _lProducto.EliminarProducto(idProducto);
            return new JsonResult("Eliminado Correctamente.");
        }

        [HttpGet("ConsultarFacturas")]
        public async Task<IEnumerable<Factura>> ConsultarFacturas()
        {
            return await _lProducto.ConsultarFacturas();
        }

        //[HttpGet("ConsultarFacturas")]
        //public IEnumerable<Factura> ConsultarFacturas()
        //{
        //    return _lProducto.ConsultarFacturas();
        //}

        //[HttpGet("ConsultarProductosInstancia")]
        //public IEnumerable<Producto> ConsultarProductos2()
        //{
        //    LProducto lProducto = new LProducto(_rProducto);
        //    return lProducto.ConsultarProductos();
        //}
    }
}
