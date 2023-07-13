using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InyeccionDependencias.Entidades.Modelo
{
    public class Factura
    {
        [Key]
        public int IdFactura { get; set; }
        public string NumeroFactura { get; set; }
        public int IdCliente { get; set; }
        public DateTime Fecha { get; set; }
        public decimal TotalIva { get; set; }
        public decimal TotaFactura { get; set; }

        [NotMapped]
        public List<DetalleFactura> Detalle { get; set; }

    }
}
