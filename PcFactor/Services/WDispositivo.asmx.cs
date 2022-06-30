using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Services
{
    /// <summary>
    /// Summary description for WDispositivo
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WDispositivo : System.Web.Services.WebService
    {

        [WebMethod]
        public DataSet Listar()
        {
            DataSet Dispositivo = Conexion.CDispositivo.Listar();
            return Dispositivo;
        }
        [WebMethod]
        public string Insertar( string rut)
        {
            string estado;
            estado = Conexion.CDispositivo.Insert(rut);

            return estado;
        }
        [WebMethod]
        public DataSet Buscar(int id)
        {
            DataSet Dispositivo = Conexion.CDispositivo.Buscar(id);
            return Dispositivo;
        }
    }
}
