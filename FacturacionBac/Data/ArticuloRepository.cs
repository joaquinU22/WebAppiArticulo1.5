using Facturacion1._5.Data.Implementations;
using Facturacion1._5.Domain;
using Facturacion1._5.Utils;
using FacturacionBackk.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturacion1._5.Data.Utils
{
    public class ArticuloRepository : IArticuloRepository
    {
        public bool InsertarArticulo(Articulo articulo)
        {
            var parameters = new List<ParametersSQL>
            {
               new ParametersSQL("@Nombre", articulo.Nombre),
               new ParametersSQL("@PrecioUnitario", articulo.PrecioUnitario),
            };
            int filasAfectadas = DataHelper.GetInstance().ExecuteSPDML("sp_AgregarArticulo", parameters);
            return filasAfectadas > 0;
        }

        public bool BorrarArticulo(int id)
        {
            var parameters = new List<ParametersSQL>
            {
                 new ParametersSQL("@Id", id)
            };

            int rowsAffected = DataHelper.GetInstance().ExecuteSPDML("sp_EliminarArticuloConDetalles", parameters);

            return rowsAffected > 0;

        }
       
        public List<Articulo> ObtenerArticulo()
        {
            DataTable tabla = DataHelper.GetInstance().Consultar("sp_TraerArticulos");
            List<Articulo> lista = new List<Articulo>();
            foreach (DataRow row in tabla.Rows) 
            { 
                int id = Convert.ToInt32(row["Id"]);
                string nombre = row["Nombre"].ToString();
                double precioUnitario = Convert.ToDouble(row["PrecioUnitario"]);
                Articulo a = new Articulo(id,nombre,precioUnitario);
                lista.Add(a);
            }
            return lista;   
        }

        public bool ActuaslizarArticulo(Articulo articulo)
        {
            var parameters = new List<ParametersSQL>
            {
                new ParametersSQL("@Id", articulo.Id),
                new ParametersSQL("@Nombre", articulo.Nombre),
                new ParametersSQL("@PrecioUnitario", articulo.PrecioUnitario)
            };
            int filasAfectadas = DataHelper.GetInstance().ExecuteSPDML("sp_ActualizarArticulo", parameters);
            return filasAfectadas > 0;

        }
    }
}
