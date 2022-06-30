using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace PcFactorWebServicesTwo
{
    /// <summary>
    /// Summary description for WSFase
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WSFase : System.Web.Services.WebService
    {

        [WebMethod]
        public DataSet Listar()
        {
            DataSet Fases = Conexion.CFase.Listar();
            return Fases;
        }
    }
}
