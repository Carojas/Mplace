using EntidadesNegocio.Administrar;
using System.Collections.Generic;

namespace MPlace_Administrar.Logica.Interface
{
    public interface IAdministrar
    {
        public List<TipoPersonaDto> ConsultarTiposPersonas();
    }
}