using EntidadesNegocio.Administrar;
using MPlace_Administrar.Logica.Interface;
using MPlace_Administrar.Repositorio.Entidades;
using MPlace_Administrar.Repositorio.Implementa;
using MPlace_Administrar.Repositorio.Interface;
using System.Collections.Generic;
using System.Linq;

namespace MPlace_Administrar.Logica.Implementa
{
    public class Administrar : IAdministrar
    {
        private IRTipoPersona _tipoPersona;
        public Administrar(IRTipoPersona tipoPersona) 
        {
            _tipoPersona = tipoPersona;
        }

        #region Tipo Persona
        public List<TipoPersonaDto> ConsultarTiposPersonas()
        {
            List<TipoPersonaViewModel> tiposPersona = _tipoPersona.ConsultarTiposPersonas();
            return tiposPersona.Select(tp => MapearTipoPersonaViewModelATipoPersonaDto(tp)).ToList();
        }

        #endregion


        #region Mapeos
        public TipoPersonaDto MapearTipoPersonaViewModelATipoPersonaDto(TipoPersonaViewModel tipopersona)
        {
            return new TipoPersonaDto
            {
                Id = tipopersona.IdTipoPersona,
                Descripcion = tipopersona.Descripcion,
                Estado = new EstadoDto()
                {
                    Id = tipopersona.IdEstado
                }
            };
        }
        public TipoPersonaViewModel MapearTipoPersonaDtoATipoPersonaViewModel(TipoPersonaDto tipoPersonaDto)
        {
            return new TipoPersonaViewModel
            {
                IdTipoPersona = tipoPersonaDto.Id,
                Descripcion = tipoPersonaDto.Descripcion,
                IdEstado = tipoPersonaDto.Estado.Id
            };
        }
        #endregion Mapeos
    }
}
