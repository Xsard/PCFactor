using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    class DBoleta
    {
        private int idBoleta;
        private DHistorialReparacion historialReparacion;
        private string descripcion;
        private DateTime fecha;
        private int monto;

        public int IdBoleta { get => idBoleta; set => idBoleta = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
        public int Monto { get => monto; set => monto = value; }
        internal DHistorialReparacion HistorialReparacion { get => historialReparacion; set => historialReparacion = value; }
    }
}
