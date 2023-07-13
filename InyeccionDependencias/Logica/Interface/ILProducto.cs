using InyeccionDependencias.Entidades.Modelo;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InyeccionDependencias.Logica.Interface
{
    public interface ILProducto
    {
        public List<Producto> ConsultarProductos();
        public Producto IngresarProducto(Producto producto);
        public Producto ActualizarProducto(Producto producto);
        public bool EliminarProducto(int idProducto);

        public Task<List<Factura>> ConsultarFacturas();
    }
}
