using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Services
{
    /// <summary>
    /// Summary description for WAdmin
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WAdmin : System.Web.Services.WebService
    {

        [WebMethod]
        public DataSet Listar()
        {
            DataSet Administradores = Conexion.CAdmin.Listar();
            return Administradores;
        }

        [WebMethod]
        public string Insertar(string email, string pass, string rut, string nombre, string apellido, int telefono)
        {
            string estado;
            string nRut = rut.Split('-').First();
            string dvRut = rut.Split('-').Last();
            if (ReglasNegocio.ReglasPersonas.ValidaRut(nRut,dvRut))
            {
                DAdmin dAdmin = new DAdmin
                {
                    Email = email,
                    Pass = pass,
                    Rut = rut,
                    Nombre = nombre,
                    Apellido = apellido,
                    Telefono = telefono
                };

                estado = Conexion.CAdmin.Insert(dAdmin);
            }
            else
            {
                estado = "Rut inválido";
            }

            return estado;
        }
        [WebMethod]
        public DataSet Buscar(string rut)
        {
            DataSet Admin = Conexion.CAdmin.Buscar(rut);
            return Admin;
        }
    }
}
