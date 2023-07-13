using MPlace_Administrar.Repositorio.Entidades;
using MPlace_Administrar.Repositorio.Interface;
using System.Collections.Generic;
using System.Linq;

namespace MPlace_Administrar.Repositorio.Implementa
{
    public class RTipoPersona : IRTipoPersona
    {
        private DataContexto _db;
        public RTipoPersona(DataContexto db)
        {
            _db = db;

        }
        public List<TipoPersonaViewModel> ConsultarTiposPersonas()
        {
            return _db.TipoPersona.ToList();
        }
    }
}
