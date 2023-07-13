using EntidadesNegocio.Administrar;
using Microsoft.AspNetCore.Mvc;
using MPlace_Administrar.Logica.Interface;
using System.Collections.Generic;

namespace MPlace_Administrar.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdministrarController : Controller
    {
        public IAdministrar _administrar;
        public AdministrarController(IAdministrar administrar)
        {
            _administrar = administrar;
        }
        [HttpGet("ConsultarTipoPersona")]
        public List<TipoPersonaDto> ConsultarTipoPersona()
        {
            return _administrar.ConsultarTiposPersonas();
        }
    }
}
