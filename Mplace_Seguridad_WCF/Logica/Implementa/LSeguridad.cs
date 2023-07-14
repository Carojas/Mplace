using Mplace_Seguridad_WCF.Repositorio.Implementa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mplace_Seguridad_WCF.Logica.Implementa
{
    public class LSeguridad : ILSeguridad
    {
        private IRSeguridad RSeguridad = UnityMplace.RSeguridad();
        public UsuarioDto RegistrarUsuario(UsuarioDto usuarioDto) 
        {
            return RSeguridad.RegistrarUsuario(usuarioDto);
        }
    }
}