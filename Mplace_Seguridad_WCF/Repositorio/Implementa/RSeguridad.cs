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
                Login = usuarioDto.Usuario,
                Password = usuarioDto.Password,
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
    }
}