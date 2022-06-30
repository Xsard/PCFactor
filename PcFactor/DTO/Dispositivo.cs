using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Dispositivo
    {
        private int idDispositivo;
        private DCliente dueño;

        public int IdDispositivo { get => idDispositivo; set => idDispositivo = value; }
        internal DCliente Dueño { get => dueño; set => dueño = value; }
    }
}
