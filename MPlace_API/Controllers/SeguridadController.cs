using EntidadesNegocio.Administrar;
using EntidadesNegocio.Seguridad;
using Microsoft.AspNetCore.Mvc;
using MPlace_API.Servicios.Administrar.Implementa;
using MPlace_API.Servicios.Administrar.Interface;
using MPlace_API.Servicios.Seguridad.Interface;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MPlace_API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SeguridadController : ControllerBase
    {

        private IUsuarioServicio _usuarioServicio;
        public SeguridadController(IUsuarioServicio usuarioServicio)
        {
            _usuarioServicio = usuarioServicio;
        }

        [HttpPost("RegistrarUsuario")]
        public async Task<ActionResult<UsuarioDto>> RegistrarUsuario([FromBody]UsuarioDto user)
        {
            if (user is null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            var result = await _usuarioServicio.RegistrarUsuario(user);
            return Ok(result);
        }
    }
}
