using System.ComponentModel.DataAnnotations;

namespace InyeccionDependencias.Entidades.Modelo
{
    public class DetalleFactura
    {
        [Key]
        public int IdDetalleFactura { get; set; }
        public int IdFactura { get; set; }
        public int IdProducto { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public decimal ValorIva { get; set; }
       
    }
}
