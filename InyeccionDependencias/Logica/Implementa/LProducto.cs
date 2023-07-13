using InyeccionDependencias.Logica.Interface;
using InyeccionDependencias.Entidades.Modelo;
using InyeccionDependencias.Repositorio;
using InyeccionDependencias.Repositorio.Interface;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InyeccionDependencias.Logica
{
    public class LProducto : ILProducto
    {
        private readonly IRProducto rProducto;
        private readonly IRFactura rFactura;
        public LProducto(IRProducto _rProducto, IRFactura _rFactura)
        {
            this.rProducto = _rProducto;
            this.rFactura = _rFactura;
        }

        public Producto ActualizarProducto(Producto producto)
        {
            return rProducto.ActualizarProducto(producto);
        }

        public async Task<List<Factura>> ConsultarFacturas()
        {
            return await rFactura.ConsultarFacturas();
        }

        public List<Producto> ConsultarProductos() 
        { 
            return rProducto.ConsultarProductos();
        }

        public bool EliminarProducto(int idProducto)
        {
            return rProducto.EliminarProducto(idProducto);
        }

        public Producto IngresarProducto(Producto producto)
        {
            return rProducto.IngresarProducto(producto);
        }
    }
}
