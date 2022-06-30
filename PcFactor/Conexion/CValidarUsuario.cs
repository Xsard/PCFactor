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
    public class CValidarUsuario
    {
        public static int ValidarUsuario(string email, string pass)
        {
            int validado;
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand Comando = new SqlCommand("Tipo_Usuario", SqlCon)
                {
                    CommandType = CommandType.StoredProcedure
                };
                Comando.Parameters.AddWithValue("@Email", email);
                Comando.Parameters.AddWithValue("@Pass", pass);

                var returnParameter = Comando.Parameters.Add("@ReturnVal", SqlDbType.Int);
                returnParameter.Direction = ParameterDirection.ReturnValue;

                SqlCon.Open();
                Comando.ExecuteNonQuery();
                var resultado = returnParameter.Value;
                validado = int.Parse(resultado.ToString());
            }
            catch (Exception)
            {
                validado = 0;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return validado;
        }
        public static int EliminarUsuario(string email)
        {
            int eliminado;
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand Comando = new SqlCommand("EliminarUsuario", SqlCon)
                {
                    CommandType = CommandType.StoredProcedure
                };
                Comando.Parameters.AddWithValue("@Email", email);

                var returnParameter = Comando.Parameters.Add("@ReturnVal", SqlDbType.Int);
                returnParameter.Direction = ParameterDirection.ReturnValue;

                SqlCon.Open();
                Comando.ExecuteNonQuery();
                var resultado = returnParameter.Value;
                eliminado = int.Parse(resultado.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(">>>>>>>>" + ex.Message);
                eliminado = 0;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return eliminado;
        }
    }
}
