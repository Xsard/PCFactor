using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conexion
{
    public class CDispositivo
    {
        public static DataSet Listar()
        {
            DataSet Dispositivo = new DataSet();
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand cmd = new SqlCommand("ListarHistoriales", SqlCon);
                SqlDataAdapter adapter = new SqlDataAdapter();
                cmd.CommandType = CommandType.StoredProcedure;
                SqlCon.Open();
                adapter.SelectCommand = cmd;
                adapter.Fill(Dispositivo);
            }
            catch (Exception ex)
            {

                Console.WriteLine(">>>>>>>" + ex);
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return Dispositivo;
        }
        public static string Insert(string Rut)
        {
            string Estado = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand Comando = new SqlCommand("InsertarDispositivo", SqlCon)
                {
                    CommandType = CommandType.StoredProcedure
                };
                Comando.Parameters.AddWithValue("@Rut", Rut);
                var returnParameter = Comando.Parameters.Add("@ReturnVal", SqlDbType.Int);
                returnParameter.Direction = ParameterDirection.ReturnValue;

                SqlCon.Open();
                Comando.ExecuteNonQuery();
                var resultado = returnParameter.Value;
                Estado = resultado.ToString();
            }
            catch (Exception ex)
            {
                Estado = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return Estado;
        }
        public static DataSet Buscar(int id)
        {
            DataSet Dispositivo = new DataSet();
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand cmd = new SqlCommand("VerDispositivo", SqlCon);
                cmd.Parameters.AddWithValue("@Id",id);
                SqlDataAdapter adapter = new SqlDataAdapter();
                cmd.CommandType = CommandType.StoredProcedure;
                SqlCon.Open();
                adapter.SelectCommand = cmd;
                adapter.Fill(Dispositivo);
            }
            catch (Exception ex)
            {

                Console.WriteLine(">>>>>>>" + ex);
            }
            finally 
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return Dispositivo;
        }
    }
}
