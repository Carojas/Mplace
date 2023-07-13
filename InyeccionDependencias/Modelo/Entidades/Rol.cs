using System.ComponentModel.DataAnnotations;

namespace InyeccionDependencias.Entidades.Modelo
{
    public class Rol
    {
        [Key]
        public int IdRol { get; set; }
        public string Descripcion { get; set; }
        public int IdEstado { get; set; }
    }
}
