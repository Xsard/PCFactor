using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conexion
{
    public class CHistorial
    {
        public static DataSet Buscar(string rut)
        {
            DataSet Historial = new DataSet();
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand cmd = new SqlCommand("HistorialTecnico", SqlCon);
                cmd.Parameters.AddWithValue("@RutTecnico", rut);
                SqlDataAdapter adapter = new SqlDataAdapter();
                cmd.CommandType = CommandType.StoredProcedure;
                SqlCon.Open();
                adapter.SelectCommand = cmd;
                adapter.Fill(Historial);
            }
            catch (Exception ex)
            {

                Console.WriteLine(">>>>>>>" + ex);
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return Historial;
        }
        public static DataSet BuscarCli(string email)
        {
            DataSet Historial = new DataSet();
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand cmd = new SqlCommand("HistorialCliente", SqlCon);
                cmd.Parameters.AddWithValue("@Email", email);
                SqlDataAdapter adapter = new SqlDataAdapter();
                cmd.CommandType = CommandType.StoredProcedure;
                SqlCon.Open();
                adapter.SelectCommand = cmd;
                adapter.Fill(Historial);
            }
            catch (Exception ex)
            {

                Console.WriteLine(">>>>>>>" + ex);
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return Historial;
        }
        public static int Actualizar(int id, string des, string estado, int fase)
        {
            int Historial=0;
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand cmd = new SqlCommand("ActualizarHistorial", SqlCon);
                cmd.Parameters.AddWithValue("@IdReparacion", id);
                cmd.Parameters.AddWithValue("@Desc", des);
                cmd.Parameters.AddWithValue("@Estado", estado);
                cmd.Parameters.AddWithValue("@Fase", fase);
                cmd.CommandType = CommandType.StoredProcedure;
                var returnParameter = cmd.Parameters.Add("@ReturnVal", SqlDbType.Int);
                returnParameter.Direction = ParameterDirection.ReturnValue;
                SqlCon.Open();
                cmd.ExecuteNonQuery();
                var resultado = returnParameter.Value;
                Historial = int.Parse(resultado.ToString());
            }
            catch (Exception ex)
            {

                Console.WriteLine(">>>>>>>" + ex);
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return Historial;
        }

        public static int Insertar( string RutCliente, string RutAdmin, string rutTecnico, string estado,string descripcion)  //ID_DISPOSITIVO,RUT_TECNICO,RUT_ADMIN,ID_FASE,ESTADO,DESCRIPCION
        {
            int Historial = 0;
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand cmd = new SqlCommand("CrearHistorial", SqlCon);
                cmd.Parameters.AddWithValue("@RutCli", RutCliente);
                cmd.Parameters.AddWithValue("@RutAdmin", RutAdmin);
                cmd.Parameters.AddWithValue("@RutTec", rutTecnico);
                cmd.Parameters.AddWithValue("@Estado", estado);
                cmd.Parameters.AddWithValue("@Desc", descripcion);
                cmd.CommandType = CommandType.StoredProcedure;
                var returnParameter = cmd.Parameters.Add("@ReturnVal", SqlDbType.Int);
                returnParameter.Direction = ParameterDirection.ReturnValue;
                SqlCon.Open();
                cmd.ExecuteNonQuery();
                var resultado = returnParameter.Value;
                Historial = int.Parse(resultado.ToString());
            }
            catch (Exception ex)
            {

                Console.WriteLine(">>>>>>>" + ex);
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return Historial;
        }
    }
}
