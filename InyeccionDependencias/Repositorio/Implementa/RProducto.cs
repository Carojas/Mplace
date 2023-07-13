using InyeccionDependencias.Entidades.Modelo;
using InyeccionDependencias.Modelo;
using InyeccionDependencias.Modelo.Interface;
using InyeccionDependencias.Repositorio.Interface;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace InyeccionDependencias.Repositorio
{
    public class RProducto : Persistencia, IRProducto
    {
        //private DataContexto db { get; set; }
        //private readonly IRFactura _fabrica;
        //public RProducto(IRFactura fabrica)
        //{
        //    _fabrica = fabrica;
        //}
        public RProducto(IRFabrica _fabrica) : base(_fabrica)
        {
            
        }

        public List<Producto> ConsultarProductos()
        {
            return  Contexto.Producto.ToList();
        }

        public Producto IngresarProducto(Producto producto)
        {
            Contexto.Producto.Add(producto);
            Contexto.SaveChanges();
            return producto;
        }

        public Producto ActualizarProducto(Producto producto)
        {
            Contexto.Entry(producto).State = EntityState.Modified;
            Contexto.SaveChanges();
            return producto;
        }

        public bool EliminarProducto(int idProducto)
        {
            Producto productoEntity = Contexto.Producto.FirstOrDefault(m => m.IdProducto == idProducto);

            if (productoEntity != null)
            {
                Contexto.Producto.Remove(productoEntity);
                Contexto.SaveChanges();
                return true;
            }
            else 
            {
                return false;
            }
        }
    }
}
