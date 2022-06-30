using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Services
{
    /// <summary>
    /// Summary description for ValidarUsuarios
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class ValidarUsuarios : System.Web.Services.WebService
    {

        [WebMethod]
        public int ValidarUsuario(string email, string pass)
        {
            int validado = Conexion.CValidarUsuario.ValidarUsuario(email, pass);
            return validado; 
        }
        [WebMethod]
        public int Eliminar(string email)
        {
            int eliminado = Conexion.CValidarUsuario.EliminarUsuario(email);
            return eliminado;
        }
    }
}

