using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MPlace_Administrar.Repositorio.Entidades
{
    [Table("TipoPersona")]
    public class TipoPersonaViewModel
    {
        [Key]
        public int IdTipoPersona { get; set; }
        public string Descripcion { get; set; }
        public int IdEstado { get; set; }
    }
}
