using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{ 
    public class DOrden
    {
        private int orden;
        private int precio;
        private string sesion;
        private string rut;
        private string estado;

        public int Orden { get => orden; set => orden = value; }
        public int Precio { get => precio; set => precio = value; }
        public string Sesion { get => sesion; set => sesion = value; }
        public string Rut { get => rut; set => rut = value; }
        public string Estado { get => estado; set => estado = value; }
    }
}
