using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using Facturacion1._5.Utils;

namespace FacturacionBackk.Data
{
    public class DataHelper
    {
        private static DataHelper instancia = null;
        private SqlConnection conexion;
        private DataHelper()
        {
            conexion = new SqlConnection("Data Source=DESKTOP-C1J1PRA\\MSSQL2022;Initial Catalog=Facturacion152;Integrated Security=True");


        }
        public static DataHelper GetInstance()
        {
            if (instancia == null)
                instancia = new DataHelper();
            return instancia;
        }
        public SqlConnection GetConnection()
        {
            return conexion;
        }
        public DataTable Consultar(string nombreSP, List<SqlParameter>? parameters = null)
        {
            conexion.Open();
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion;
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = nombreSP;

            if (parameters != null)
            {
                foreach (var param in parameters)
                    comando.Parameters.AddWithValue(param.ParameterName, param.Value);
            }

            DataTable tabla = new DataTable();
            tabla.Load(comando.ExecuteReader());
            conexion.Close();
            return tabla;
        }
        public int ExecuteSPDML(string sp, List<ParametersSQL>? parameters)
        {
            int rows;
            try
            {
                conexion.Open();
                var cmd = new SqlCommand(sp, conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                if (parameters != null)
                {
                    foreach (var param in parameters)
                        cmd.Parameters.AddWithValue(param.Name, param.Value);
                }

                rows = cmd.ExecuteNonQuery();
                conexion.Close();
            }
            catch (SqlException)
            {
                rows = 0;
            }
            finally
            {
                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }

            return rows;
        }
    }
}

