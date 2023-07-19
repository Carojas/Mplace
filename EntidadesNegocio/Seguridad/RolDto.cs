using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesNegocio.Seguridad
{
    public class RolDto
    {
        public int IdRol { get; set; }
        public string Descripcion { get; set; }
        public int IdEstado { get; set; }
    }
}
