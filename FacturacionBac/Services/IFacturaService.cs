using Facturacion1._5.Domain;
using FacturacionBackk.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturacionBackk.Services
{
    public interface IFacturaService
    {
        List<FormaPago> ObtenerFormaPagos();
        List<Factura> ObtenerFactura();
        public bool AgregarFactura(Factura factura);
        public bool BorrarFactura(int Id);
    }
}
