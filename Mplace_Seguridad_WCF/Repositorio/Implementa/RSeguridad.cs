using Mplace_Seguridad_WCF.Repositorio.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mplace_Seguridad_WCF.Repositorio.Implementa
{
    public class RSeguridad : IRSeguridad
    {
        public UsuarioDto RegistrarUsuario(UsuarioDto usuarioDto) 
        {
            using (var db = new MPlaceEntities())
            {
                Usuario usuario = MapearDataModelo(usuarioDto);
                db.Usuario.Add(usuario);
                db.SaveChanges();
                return usuarioDto;
            }
        }
        private Usuario MapearDataModelo(UsuarioDto usuarioDto)
        {
            return new Usuario()
            {
                Login = usuarioDto.Usuario.Substring(0,8),
                Password = usuarioDto.Password,
                Identificacion ="123",
                IdEstado = 1,
                IdRol = 1,
                Nombre = $"Prueba {usuarioDto.Usuario}",
            };
        }
        private UsuarioDto MapearDataDto(Usuario usuarioDto)
        {
            return new UsuarioDto()
            {
                Usuario = usuarioDto.Login,
                Password = usuarioDto.Password,
            };
        }

        public List<RolDto> ConsultarRoles()
        {
            using (var db = new MPlaceEntities())
            {
                return db.Rol.Select(s=>new RolDto() {IdRol =  s.IdRol, Descripcion = s.Descripcion, IdEstado = s.IdEstado}).ToList();
            }
        }

        public bool Login(UsuarioDto usuario)
        {
            using (var db = new MPlaceEntities())
            {
                return db.Usuario.Any(a => a.Login == usuario.Usuario && a.Password == usuario.Password);
            }
        }
    }
}