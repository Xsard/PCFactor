using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DTO;

namespace Conexion
{
    public class CAdmin
    {
        public static DataSet Listar()
        {
            DataSet Administradores = new DataSet();
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand cmd = new SqlCommand("ListarAdministrador", SqlCon);
                SqlDataAdapter adapter = new SqlDataAdapter();
                cmd.CommandType = CommandType.StoredProcedure;
                SqlCon.Open();
                adapter.SelectCommand = cmd;
                adapter.Fill(Administradores);
            }
            catch (Exception ex)
            {
                Console.WriteLine(">>>>>>>" + ex);
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return Administradores;            
        }

        public static string Insert(DAdmin cAdmin)
        {
            string Estado = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand Comando = new SqlCommand("InsertAdmin", SqlCon)
                {
                    CommandType = CommandType.StoredProcedure
                };
                Comando.Parameters.AddWithValue("@EmailAD", cAdmin.Email);
                Comando.Parameters.AddWithValue("@PassAd", cAdmin.Pass);
                Comando.Parameters.AddWithValue("@Rut", cAdmin.Rut);
                Comando.Parameters.AddWithValue("@Nombre", cAdmin.Nombre);
                Comando.Parameters.AddWithValue("@Apellido", cAdmin.Apellido);
                Comando.Parameters.AddWithValue("@Telefono", cAdmin.Telefono);

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
            DataSet Admin = new DataSet();
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand cmd = new SqlCommand("BuscarAdmin", SqlCon);
                cmd.Parameters.AddWithValue("@Rut", rut);
                SqlDataAdapter adapter = new SqlDataAdapter();
                cmd.CommandType = CommandType.StoredProcedure;
                SqlCon.Open();
                adapter.SelectCommand = cmd;
                adapter.Fill(Admin);
            }
            catch (Exception ex)
            {

                Console.WriteLine(">>>>>>>" + ex);
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return Admin;
        }
        public static string Update(string Rut, int Telefono)
        {
            string Estado = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand Comando = new SqlCommand("ActualizarAdmin", SqlCon)
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
