using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturacion1._5.Domain
{
    public class Articulo
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public double PrecioUnitario { get; set; } 
        public Articulo() 
        {
            Id = 0;
            Nombre = string.Empty;
            PrecioUnitario = 0;
        }
        public Articulo(int id, string nombre, double precioUnitario)
        {
            Id = id;
            Nombre = nombre;
            PrecioUnitario = precioUnitario;
        }
        public override string ToString()
        {
            return Nombre + ' ' + PrecioUnitario;
        }
    }
}
