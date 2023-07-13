using MPlace_Administrar.Repositorio.Entidades;
using System.Collections.Generic;

namespace MPlace_Administrar.Repositorio.Interface
{
    public interface IRTipoPersona
    {
        public List<TipoPersonaViewModel> ConsultarTiposPersonas();
    }
}