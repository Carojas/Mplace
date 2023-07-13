
using InyeccionDependencias.Entidades.Modelo;
using System.Collections.Generic;

namespace InyeccionDependencias.Repositorio.Interface
{
    public interface IRProducto
    {
        public List<Producto> ConsultarProductos();
        public Producto IngresarProducto(Producto producto);
        public Producto ActualizarProducto(Producto producto);
        public bool EliminarProducto(int idProducto);
    }
}
