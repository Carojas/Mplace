using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MPlace_API.Servicios.Administrar.Interface;
using System.Collections.Generic;
using System.Linq;
using System;
using EntidadesNegocio.Administrar;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace MPlace_API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AdministrarController : ControllerBase
    {
        private ITipoPersonaServicio _tipoPersonaServicio;
        public AdministrarController(ITipoPersonaServicio tipoPersonaServicio)
        {
            _tipoPersonaServicio = tipoPersonaServicio;
        }


        [HttpGet("ConsultaTipoPersona")]
        public async Task<List<TipoPersonaDto>> ConsultaTipoPersona()
        {
            return await _tipoPersonaServicio.ConsultaTipoPersona();
        }
    }
}
