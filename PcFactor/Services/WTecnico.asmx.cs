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
    /// Summary description for WTecnico
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WTecnico : System.Web.Services.WebService
    {
        [WebMethod]
        public DataSet Listar()
        {
            DataSet Tecnicos = Conexion.CTecnico.Listar();
            return Tecnicos;
        }

        [WebMethod]
        public string Insertar(string email, string pass, string rut, string nombre, string apellido, int telefono)
        {
            string estado;
            string nRut = rut.Split('-').First();
            string dvRut = rut.Split('-').Last();
            if (ReglasNegocio.ReglasPersonas.ValidaRut(nRut,dvRut))
            {
                DTecnico dTecnico = new DTecnico
                {
                    Email = email,
                    Pass = pass,
                    Rut = rut,
                    Nombre = nombre,
                    Apellido = apellido,
                    Telefono = telefono
                };

                estado = Conexion.CTecnico.Insert(dTecnico);
            }
            else
            {
                estado = "Rut inválido";
            }


            return estado;
        }
        [WebMethod]
        public DataSet Buscar(string email)
        {
            DataSet Tec = Conexion.CTecnico.Buscar(email);
            return Tec;
        }
    }
}
