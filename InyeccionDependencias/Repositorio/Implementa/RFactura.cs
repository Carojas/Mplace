
using InyeccionDependencias.Entidades.Modelo;
using InyeccionDependencias.Modelo;
using InyeccionDependencias.Modelo.Interface;
using InyeccionDependencias.Repositorio.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace InyeccionDependencias.Repositorio.Implementa
{
    public class RFactura : Persistencia, IRFactura
    {
        //private DataContexto db { get; set; }
        //public RFactura(DataContexto _db)
        //{
        //    db = _db;
        //}
        public RFactura(IRFabrica _fabrica):base(_fabrica)
        {
                
        }

        public async Task<List<Factura>> ConsultarFacturas()
        {
            var facturas = from factura in Contexto.Factura.ToList()
                           join detalleFactura in Contexto.DetalleFactura.ToList()
                                           on factura.IdFactura equals detalleFactura.IdFactura
                           join producto in Contexto.Producto.ToList()
                                   on detalleFactura.IdProducto equals producto.IdProducto
                           select new { factura, detalleFactura, producto };

            return await Task.Run(() => facturas.Select(factura => factura.factura).ToList());
        }

    }
}
