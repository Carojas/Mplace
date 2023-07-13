using EntidadesNegocio.Administrar;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MPlace_API.Servicios.Administrar.Interface
{
    public interface ITipoPersonaServicio
    {
        public Task<List<TipoPersonaDto>> ConsultaTipoPersona();
    }
}