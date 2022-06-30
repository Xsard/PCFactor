using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using Conexion;
using PcFactorWebServicesTwo.WSTec;

namespace PcFactorWebServicesTwo
{
    /// <summary>
    /// Summary description for WSHistorial
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WSHistorial : System.Web.Services.WebService
    {

        [WebMethod]
        public DataSet Buscar(string email)
        {
            WTecnicoSoapClient wTecnico = new WTecnicoSoapClient();
            DataSet ds = wTecnico.Buscar(email);
            try
            {
                string rut = ds.Tables[0].Rows[0]["RUT_TECNICO"].ToString();
                DataSet His = Conexion.CHistorial.Buscar(rut);
                return His;
            }
            catch (Exception)
            {

                return null;
            }

        }
        [WebMethod]
        public DataSet BuscarCli(string email)
        {
            try
            {
                DataSet His = Conexion.CHistorial.BuscarCli(email);
                return His;
            }
            catch (Exception)
            {

                return null;
            }

        }
        [WebMethod]
        public int Actualizar(int id, string des, string estado, int fase, int precio = 0)
        {
            int updated = ReglasNegocio.ReglaDiagnostico.generarOrden(id, des, estado, fase, precio);
            return updated;
        }
        [WebMethod]
        public int Insertar(string RutCliente, string RutAdmin, string rutTecnico, string estado, string descripcion)  
        {
            int inserted;
            inserted = CHistorial.Insertar(RutCliente, RutAdmin, rutTecnico, estado, descripcion);
            return inserted;
        }
        [WebMethod]
        public DataSet BuscarOrden(int id_historial)
        {
            try
            {
                DataSet Orden = Conexion.COrden.BuscarOrden(id_historial);
                return Orden;
            }
            catch (Exception)
            {

                return null;
            }
        }
        [WebMethod]
        public int OrdenPagada(int id_historial)
        {
            int Pagado;
            Pagado = COrden.OrdenPagada(id_historial);
            return Pagado;
        }
    }
}
