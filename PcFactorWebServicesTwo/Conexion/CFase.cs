using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conexion
{
    public class CFase
    {
        public static DataSet Listar()
        {
            DataSet Fase = new DataSet();
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand cmd = new SqlCommand("ListarFases", SqlCon);
                SqlDataAdapter adapter = new SqlDataAdapter();
                cmd.CommandType = CommandType.StoredProcedure;
                SqlCon.Open();
                adapter.SelectCommand = cmd;
                adapter.Fill(Fase);
            }
            catch (Exception ex)
            {
                Console.WriteLine(">>>>>>>" + ex);
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return Fase;
        }
    }
}
