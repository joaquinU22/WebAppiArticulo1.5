using Facturacion1._5.Data.Implementations;
using Facturacion1._5.Data.Utils;
using Facturacion1._5.Domain;
using FacturacionBackk.Data;
using FacturacionBackk.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturacionBackk.Services
{
    public class FacturaService:IFacturaService
    {
        private IFormaPagoRepository repository;
        private IFacturaRepository facturas;
        public FacturaService()
        {
            repository = new FormaPagoRepository();
            facturas = new FacturaRepository();
        }
        // GET: api/<FormaPagoRepository>
        public List<Factura> ObtenerFactura()
        {
            return facturas.ObtenerFactura();
        }
        public bool AgregarFactura(Factura factura)
        {
            return facturas.AgregarFactura(factura);
        }
        public bool BorrarFactura(int Id)
        {
            return facturas.BorrarFactura(Id);
        }
        // POST api/<ObtenerFormaPagos>
        public List<FormaPago> ObtenerFormaPagos() 
        {
            return repository.ObtenerFormaPagos();
        }

    }
}
