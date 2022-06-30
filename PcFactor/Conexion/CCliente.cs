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
    public class CCliente
    {
        public static DataSet Listar()
        {
            DataSet Clientes = new DataSet();
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand cmd = new SqlCommand("ListarClientes", SqlCon);
                SqlDataAdapter adapter = new SqlDataAdapter();
                cmd.CommandType = CommandType.StoredProcedure;
                SqlCon.Open();
                adapter.SelectCommand = cmd;
                adapter.Fill(Clientes);
            }
            catch (Exception ex)
            {
             
                Console.WriteLine(">>>>>>>" + ex);
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return Clientes;
        }

        public static string Insert(DCliente dCliente)
        {
            string Estado = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand Comando = new SqlCommand("InsertarCliente", SqlCon)
                {
                    CommandType = CommandType.StoredProcedure
                };
                Comando.Parameters.AddWithValue("@EmailAD", dCliente.Email);
                Comando.Parameters.AddWithValue("@PassAd", dCliente.Pass);
                Comando.Parameters.AddWithValue("@Rut", dCliente.Rut);
                Comando.Parameters.AddWithValue("@Nombre", dCliente.Nombre);
                Comando.Parameters.AddWithValue("@Apellido", dCliente.Apellido);
                Comando.Parameters.AddWithValue("@Direccion", dCliente.Direccion);
                Comando.Parameters.AddWithValue("@Telefono", dCliente.Telefono);
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
        public static DataSet Buscar(string rut)
        {
            DataSet Cliente = new DataSet();
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand cmd = new SqlCommand("BuscarCliente", SqlCon);
                cmd.Parameters.AddWithValue("@Rut", rut);
                SqlDataAdapter adapter = new SqlDataAdapter();
                cmd.CommandType = CommandType.StoredProcedure;
                SqlCon.Open();
                adapter.SelectCommand = cmd;
                adapter.Fill(Cliente);
            }
            catch (Exception ex)
            {

                Console.WriteLine(">>>>>>>" + ex);
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return Cliente;
        }
        public static string Update(string Rut, string Direccion, int Telefono)
        {
            string Estado = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand Comando = new SqlCommand("ActualizarCliente", SqlCon)
                {
                    CommandType = CommandType.StoredProcedure
                };
                Comando.Parameters.AddWithValue("@Rut", Rut);
                Comando.Parameters.AddWithValue("@Direccion", Direccion);
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
