using System.Collections.Generic;

namespace Mplace_Seguridad_WCF.Repositorio.Implementa
{
    public interface IRSeguridad
    {
        UsuarioDto RegistrarUsuario(UsuarioDto usuarioDto);

        List<RolDto> ConsultarRoles();

        bool Login(UsuarioDto usuario);
    }
}