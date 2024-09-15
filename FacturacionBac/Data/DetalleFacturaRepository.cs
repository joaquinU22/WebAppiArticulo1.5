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
    public class DetalleFacturaRepository : IDetalleFacturaRepository
    {
        public bool InsertarDetalle(DetalleFactura detalle)
        {
            var parametros = new List<ParametersSQL>
            {
                new ParametersSQL("@Cantidad", detalle.Cantidad),
                new ParametersSQL("@ArticuloId", detalle.Articulo.Id),
                new ParametersSQL("@IdFactura", detalle.IdFactura),
                new ParametersSQL("@precio", detalle.Precio),
            };
            int filasAfectadas = DataHelper.GetInstance().ExecuteSPDML("sp_AgregarNuevoDetalleFactura", parametros);
            return filasAfectadas > 0;
        }

        public bool BorrarDetalle(int id)
        {
            var parametros = new List<ParametersSQL>
            {
                new ParametersSQL("@IdDetalleFactura", id)
            };
            int filasAfectadas = DataHelper.GetInstance().ExecuteSPDML("sp_EliminarDetalleFactura", parametros);
            return filasAfectadas > 0;
        }

        public List<DetalleFactura> ObtenerDetalleFactura()
        {
            var detalles = new List<DetalleFactura>();
            DataTable table = DataHelper.GetInstance().Consultar("sp_TraerDetallesFactura");
            foreach(DataRow row in table.Rows)
            {
                int id = Convert.ToInt32(row["IdDetalleFactura"]);
                int cantidad = Convert.ToInt32(row["Cantidad"]);
                Articulo articulo = new Articulo
                {
                    Id = Convert.ToInt32(row["ArticuloId"]),
                    Nombre = table.Columns.Contains("Nombre") ? row["Nombre"].ToString() : string.Empty
                };
                int idFactura = Convert.ToInt32(row["IdFactura"]);
                double precio = Convert.ToDouble(row["Precio"]);
                DetalleFactura d = new DetalleFactura(id, cantidad, articulo, precio, idFactura);
                detalles.Add(d);
            }
            return detalles;
        }

        public bool ActualizarDetalle(DetalleFactura detalle)
        {
            var parametros = new List<ParametersSQL>
            {
                new ParametersSQL("@IdDetalleFactura", detalle.Id),
                new ParametersSQL("@Cantidad", detalle.Cantidad),
                new ParametersSQL("@ArticuloId", detalle.Articulo.Id),
                new ParametersSQL("@IdFactura", detalle.IdFactura),
                new ParametersSQL("@Precio", detalle.Precio)
            };
            int filasAfectadas = DataHelper.GetInstance().ExecuteSPDML("sp_ActualizarDetalleFactura", parametros);
            return filasAfectadas > 0;
        }
    }
}
