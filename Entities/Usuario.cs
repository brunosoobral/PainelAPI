using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Usuario
    {
        public string Login { get; set; }
        public string Senha { get; set; }
        public int Diretorio { get; set; }
        public Personagem[] Personagens { get; set; }
    }
}
