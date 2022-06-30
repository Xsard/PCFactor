using Conexion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReglasNegocio
{
    public class ReglaDiagnostico
    {
        public static int generarOrden(int id, string des, string estado, int fase, int precio = 0)
        {
            if (fase == 2)
            {
                int state;
                state = Conexion.COrden.CrearOrdenCompra(id, DateTime.Now.ToString() + id.ToString(), precio, 0);
                if (state == 1)
                {
                    Conexion.CHistorial.Actualizar(id, des, estado, fase);
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                Conexion.CHistorial.Actualizar(id, des, estado, fase);
                return 2;
            }
        } 
    }
}
