using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    /*-----------------------------------------
        Autor:      Bruno Sobral                  
        Skype:      bruno.soobral
        E-mail:     bruno.soobral@gmail.com
    -----------------------------------------*/

    public class Status
    {
        public int Forca { get; set; }
        public int Inteligencia { get; set; }
        public int Talento { get; set; }
        public int Agilidade { get; set; }
        public int Vitalidade { get; set; }
        public int Pontos { get; set; }

        public Status()
        {
            Pontos = 0;
        }
    }
}
