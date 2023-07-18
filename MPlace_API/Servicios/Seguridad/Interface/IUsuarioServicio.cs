using EntidadesNegocio.Seguridad;
using System.Threading.Tasks;

namespace MPlace_API.Servicios.Seguridad.Interface
{
    public interface IUsuarioServicio
    {
        Task<UsuarioDto> RegistrarUsuario(UsuarioDto usuario);
    }
}
