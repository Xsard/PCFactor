using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    class DFaseReparacion
    {
        private int idFase;
        private string descripcion;
        public int IdFase { get => idFase; set => idFase = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
    }
}
