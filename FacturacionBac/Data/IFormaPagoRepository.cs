using FacturacionBackk.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturacionBackk.Data
{
    public interface IFormaPagoRepository
    {
        List<FormaPago> ObtenerFormaPagos();
    }
}
