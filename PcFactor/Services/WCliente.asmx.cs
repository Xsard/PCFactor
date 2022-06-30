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
    /// Summary description for WCliente
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WCliente : System.Web.Services.WebService
    {

        [WebMethod]
        public DataSet Listar()
        {
            DataSet Administradores = Conexion.CCliente.Listar();
            return Administradores;
        }

        [WebMethod]
        public string Insertar(string email, string pass, string rut, string nombre, string apellido, string direccion, int telefono)
        {
            string estado;
            string nRut = rut.Split('-').First();
            string dvRut = rut.Split('-').Last();
            if (ReglasNegocio.ReglasPersonas.ValidaRut(nRut, dvRut))
            {
                DCliente dCliente = new DCliente
                {
                    Email = email,
                    Pass = pass,
                    Rut = rut,
                    Nombre = nombre,
                    Apellido = apellido,
                    Direccion = direccion,
                    Telefono = telefono
                };
                estado = Conexion.CCliente.Insert(dCliente);
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
            DataSet Cliente = Conexion.CCliente.Buscar(rut);
            return Cliente;
        }
    }
}
