using System.ComponentModel.DataAnnotations;

namespace InyeccionDependencias.Entidades.Modelo
{
    public class Producto
    {
        [Key]
        public int IdProducto { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int IdEstado { get; set; }
        public int Stock { get; set; }
        public int IdCategoria { get; set; }
        public int IdProveedorProducto { get; set; }
        public string Img { get; set; }
    }
}
