using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesNegocio.Seguridad
{
    [DataContract]
    public class UsuarioDto
    {
        [DataMember]
        public string Usuario { get; set; }
        [DataMember]
        public string Password { get; set; }
    }
}
