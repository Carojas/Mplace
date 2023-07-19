using System.Collections.Generic;

namespace Mplace_Seguridad_WCF.Logica.Implementa
{
    public interface ILSeguridad
    {
        UsuarioDto RegistrarUsuario(UsuarioDto usuarioDto);

        List<RolDto> ConsultarRoles();

        bool Login(UsuarioDto usuario);
    }
}