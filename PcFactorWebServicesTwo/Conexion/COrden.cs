using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conexion
{
    public class COrden
    {
        public static int CrearOrdenCompra(int idH, string sesion, int precio, int estado)  //ID_DISPOSITIVO,RUT_TECNICO,RUT_ADMIN,ID_FASE,ESTADO,DESCRIPCION
        {
            int Orden = 0;
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand cmd = new SqlCommand("CrearOrdenCompra", SqlCon);
                cmd.Parameters.AddWithValue("@Precio", precio);
                cmd.Parameters.AddWithValue("@Sesion", sesion);
                cmd.Parameters.AddWithValue("@Historial", idH);
                cmd.Parameters.AddWithValue("@Estado", estado);
                cmd.CommandType = CommandType.StoredProcedure;
                var returnParameter = cmd.Parameters.Add("@ReturnVal", SqlDbType.Int);
                returnParameter.Direction = ParameterDirection.ReturnValue;
                SqlCon.Open();
                cmd.ExecuteNonQuery();
                var resultado = returnParameter.Value;
                Orden = int.Parse(resultado.ToString());
            }
            catch (Exception ex)
            {

                Console.WriteLine(">>>>>>>" + ex);
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return Orden;
        }
        public static DataSet BuscarOrden(int id_historial)
        {
            DataSet OrdenCompra = new DataSet();
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand cmd = new SqlCommand("OrdenCompra", SqlCon);
                cmd.Parameters.AddWithValue("@Id_reaparacion", id_historial);
                SqlDataAdapter adapter = new SqlDataAdapter();
                cmd.CommandType = CommandType.StoredProcedure;
                SqlCon.Open();
                adapter.SelectCommand = cmd;
                adapter.Fill(OrdenCompra);
            }
            catch (Exception ex)
            {

                Console.WriteLine(">>>>>>>" + ex);
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return OrdenCompra;
        }
        public static int OrdenPagada(int id_historial)
        {
            int Pagado = 0;
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand cmd = new SqlCommand("OrdenPagada", SqlCon);
                cmd.Parameters.AddWithValue("@Id_reparacion", id_historial);
                cmd.CommandType = CommandType.StoredProcedure;
                var returnParameter = cmd.Parameters.Add("@ReturnVal", SqlDbType.Int);
                returnParameter.Direction = ParameterDirection.ReturnValue;
                SqlCon.Open();
                cmd.ExecuteNonQuery();
                var resultado = returnParameter.Value;
                Pagado = int.Parse(resultado.ToString());

            }
            catch (Exception ex)
            {

                Console.WriteLine(">>>>>>>" + ex);
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return Pagado;
        }
    }
}
