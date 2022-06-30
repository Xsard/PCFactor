using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    class DItemBoleta
    {
        private DBoleta boleta;
        private int idItem;
        private int pUnitario;
        private int cantidad;

        public int IdItem { get => idItem; set => idItem = value; }
        public int PUnitario { get => pUnitario; set => pUnitario = value; }
        public int Cantidad { get => cantidad; set => cantidad = value; }
        internal DBoleta Boleta { get => boleta; set => boleta = value; }
    }
}
