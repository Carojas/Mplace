using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesNegocio.Administrar
{
    public class TipoPersonaDto
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public EstadoDto Estado { get; set; }
    }
}
