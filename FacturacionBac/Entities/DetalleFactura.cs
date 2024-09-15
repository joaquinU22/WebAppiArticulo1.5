using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturacion1._5.Domain
{
    public class DetalleFactura
    {
        public int Id { get; set; }
        public int Cantidad {  get; set; }
        public Articulo Articulo { get; set; }
        public double Precio { get; set; }
        public int IdFactura { get; set; }
        public DetalleFactura(int id, int cantidad, Articulo articulo, double precio, int idFactura) 
        {
            Id = id;
            Cantidad = cantidad;
            Articulo = articulo;
            Precio = precio;
            IdFactura = idFactura;
        }

        public double SubTotal()
        {
            return Cantidad * Precio;
        }
    }
}
