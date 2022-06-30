using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DUser
    {
        private int idUser;
        private string email;
        private string pass;
        public int IdUser { get => idUser; set => idUser = value; }
        public string Email { get => email; set => email = value; }
        public string Pass { get => pass; set => pass = value; }
    }
}
