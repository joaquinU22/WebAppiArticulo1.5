using Facturacion1._5.Data.Implementations;
using Facturacion1._5.Domain;
using Facturacion1._5.Utils;
using FacturacionBackk.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturacion1._5.Data.Utils
{
    public class ClienteRepository : IClienteRepository
    {
        public bool InsertarCliente(Cliente cliente)
        {
            var parametros = new List<ParametersSQL>
            {
                new ParametersSQL("@Nombre",cliente.Nombre),
                new ParametersSQL("@Apellido",cliente.Apellido),
                new ParametersSQL("@Dni",cliente.Dni)
            };
            int filasAfectadas = DataHelper.GetInstance().ExecuteSPDML("sp_AgregarCliente", parametros);
            return filasAfectadas > 0;
        }

        public List<Cliente> ObtenerClientes()
        {
            var clientes = new List<Cliente>();
            DataTable table = DataHelper.GetInstance().Consultar("sp_TraerCliente", null);
            if (table != null)
            {
                foreach (DataRow row in table.Rows)
                {
                    
                    Cliente cliente = new Cliente
                    {
                        Id = Convert.ToInt32(row["Id"]),
                        Nombre = row["Nombre"].ToString(),
                        Apellido = row["Apellido"].ToString(),
                        Dni = row["Dni"].ToString()
                    };
                    clientes.Add(cliente);
                }
            }
            return clientes;
        }
        
    }
}
