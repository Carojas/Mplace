using EntidadesNegocio.Seguridad;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MPlace_API.Servicios.Seguridad.Interface
{
    public interface IUsuarioServicio
    {
        Task<UsuarioDto> RegistrarUsuario(UsuarioDto usuario);
        Task<List<RolDto>> ConsultarRoles();
        Task<bool> Login(UsuarioDto usuario);
    }
}
