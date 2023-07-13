using InyeccionDependencias.Entidades.Modelo;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InyeccionDependencias.Repositorio.Interface
{
    public interface IRFactura
    {
        public Task<List<Factura>> ConsultarFacturas();
    }
}
