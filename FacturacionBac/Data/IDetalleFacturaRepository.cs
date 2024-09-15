using Facturacion1._5.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturacion1._5.Data.Implementations
{
    public interface IDetalleFacturaRepository
    {
        bool InsertarDetalle(DetalleFactura detalle);
        List<DetalleFactura> ObtenerDetalleFactura();
        bool ActualizarDetalle(DetalleFactura detalle);
        bool BorrarDetalle(int id);
    }
}
