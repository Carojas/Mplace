using Mplace_Seguridad_WCF.Logica.Implementa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Mplace_Seguridad_WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Seguridad" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Seguridad.svc or Seguridad.svc.cs at the Solution Explorer and start debugging.
    public class Seguridad : ISeguridad
    {
        private static ILSeguridad iLSeguridad = UnityMplace.LSeguridad();

        public UsuarioDto Login()
        {
            throw new NotImplementedException();
        }

        public UsuarioDto Registrar(UsuarioDto usuarioDto)
        {
            return iLSeguridad.RegistrarUsuario(usuarioDto);
        }
    }

    [DataContract]
    public class UsuarioDto
    {
        [DataMember]
        public string Usuario { get; set; }
        [DataMember]
        public string Password { get; set; }
    }
}
