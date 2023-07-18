using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesNegocio.Seguridad
{
    public class UsuarioDto
    {
        public string Usuario { get; set; }
        public string Password { get; set; }
    }
}
