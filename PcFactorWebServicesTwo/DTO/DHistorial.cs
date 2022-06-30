using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    class DHistorial
    {
        private int idReparacion;
        private int idDispo;
        private string rutTecnico;
        private string rutAdmin;
        private DFase fase;
        private string estado;
        private string descripcion;

        public int IdReparacion { get => idReparacion; set => idReparacion = value; }
        public string RutTecnico { get => rutTecnico; set => rutTecnico = value; }
        public string RutAdmin { get => rutAdmin; set => rutAdmin = value; }
        public string Estado { get => estado; set => estado = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public int Dispo { get => idDispo; set => idDispo = value; }
        internal DFase Fase { get => fase; set => fase = value; }
    }
}
