using InyeccionDependencias.Entidades.Modelo;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace InyeccionDependencias.Modelo
{
    public class DataContexto : DbContext
    {
        public DataContexto(){}
        public DataContexto(DbContextOptions<DataContexto> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Startup.ConfigurationStartup["database:connection"]);
        }


        public DbSet<Producto> Producto { get; set; }
        //public DbSet<Rol> Rol { get; set; }
        //public DbSet<Persona> Persona { get; set; }
        //public DbSet<TipoDocumento> TipoDocumento { get; set; }
        public DbSet<Factura> Factura { get; set; }
        public DbSet<DetalleFactura> DetalleFactura { get; set; }
    }
}
