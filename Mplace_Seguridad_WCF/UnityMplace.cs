using Mplace_Seguridad_WCF.Logica.Implementa;
using Mplace_Seguridad_WCF.Repositorio.Implementa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mplace_Seguridad_WCF
{
    public static class UnityMplace
    {
        public static IRSeguridad RSeguridad() 
        {
            return new RSeguridad();
        }
        public static ILSeguridad LSeguridad()
        {
            return new LSeguridad();
        }
    }
}