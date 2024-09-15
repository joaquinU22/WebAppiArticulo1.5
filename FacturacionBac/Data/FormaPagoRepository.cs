using FacturacionBackk.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturacionBackk.Data
{
    public class FormaPagoRepository:IFormaPagoRepository
    {
        public List<FormaPago> ObtenerFormaPagos()
        {
            DataTable tabla = DataHelper.GetInstance().Consultar("sp_TraerFormasPago");
            List<FormaPago> lista = new List<FormaPago>();

            foreach (DataRow row in tabla.Rows)
            {
                int id = int.Parse(row["IdFormaPago"].ToString());
                string nombre = row["Nombre"].ToString();
                FormaPago c = new FormaPago(id, nombre);
                lista.Add(c);
            }

            return lista;
        }
    }
}
