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
    public class CTecnico
    {
        public static DataSet Listar()
        {
            DataSet Tecnicos = new DataSet();
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand cmd = new SqlCommand("ListarTecnico", SqlCon);
                SqlDataAdapter adapter = new SqlDataAdapter();
                cmd.CommandType = CommandType.StoredProcedure;
                SqlCon.Open();
                adapter.SelectCommand = cmd;
                adapter.Fill(Tecnicos);
            }
            catch (Exception ex)
            {
                Console.WriteLine(">>>>>>>" + ex);
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return Tecnicos;
        }

        public static string Insert(DTecnico dTecnico)
        {
            string Estado = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand Comando = new SqlCommand("InsertTecnico", SqlCon)
                {
                    CommandType = CommandType.StoredProcedure
                };
                Comando.Parameters.AddWithValue("@EmailAD", dTecnico.Email);
                Comando.Parameters.AddWithValue("@PassAd", dTecnico.Pass);
                Comando.Parameters.AddWithValue("@Rut", dTecnico.Rut);
                Comando.Parameters.AddWithValue("@Nombre", dTecnico.Nombre);
                Comando.Parameters.AddWithValue("@Apellido", dTecnico.Apellido);
                Comando.Parameters.AddWithValue("@Telefono", dTecnico.Telefono);

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
        public static DataSet Buscar(string email)
        {
            DataSet Tec = new DataSet();
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand cmd = new SqlCommand("BuscarTecnicoE", SqlCon);
                cmd.Parameters.AddWithValue("@Email", email);
                SqlDataAdapter adapter = new SqlDataAdapter();
                cmd.CommandType = CommandType.StoredProcedure;
                SqlCon.Open();
                adapter.SelectCommand = cmd;
                adapter.Fill(Tec);
            }
            catch (Exception ex)
            {

                Console.WriteLine(">>>>>>>" + ex);
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return Tec;
        }

        public static string Update(string Rut, int Telefono)
        {
            string Estado = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand Comando = new SqlCommand("ActualizarTecnico", SqlCon)
                {
                    CommandType = CommandType.StoredProcedure
                };
                Comando.Parameters.AddWithValue("@Rut", Rut);
                Comando.Parameters.AddWithValue("@Telefono", Telefono);

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

    }
}
