using EntidadesNegocio.Seguridad;
using MPlace_API.Servicios.Seguridad.Interface;
using System;
using System.Threading.Tasks;

namespace MPlace_API.Servicios.Seguridad.Implementa
{
    public class UsuarioServicio: IUsuarioServicio
    {
        public async Task<UsuarioDto> RegistrarUsuario(UsuarioDto usuario) 
        {
            ServiceSeguridad.SeguridadClient servicioSeguridad = new ServiceSeguridad.SeguridadClient();
            var result = await servicioSeguridad.RegistrarAsync(MapearUsuarioDtoAWCF(usuario));
            if (result != null)
            {
                return MapearUsuarioWCFADto(result);
            }
            return null;
        }

        private ServiceSeguridad.UsuarioDto MapearUsuarioDtoAWCF(UsuarioDto usuario)
        {
            return new ServiceSeguridad.UsuarioDto()
            {
                Password = usuario.Password,
                Usuario = usuario.Usuario
            };
        }
        private UsuarioDto MapearUsuarioWCFADto(ServiceSeguridad.UsuarioDto usuario)
        {
            return new UsuarioDto()
            {
                Password = usuario.Password,
                Usuario = usuario.Usuario
            };
        }
    }
}
