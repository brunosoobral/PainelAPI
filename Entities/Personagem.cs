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

    public class Personagem
    {
        public string Login { get; set; }
        public string Nickname { get; set; }
        public int Level { get; set; }
        public string Clan { get; set; }

        //Cabelo
        public string CabeloA { get; set; }
        public string CabeloB { get; set; }

        //Status
        public Status Status { get; set; }

        //Magias
        public Magias[] Tier1 { get; set; }
        public Magias[] Tier2 { get; set; }
        public Magias[] Tier3 { get; set; }
        public Magias[] Tier4 { get; set; }
        public int PontosRestanteSP { get; set; }
        public int PontosRestanteEP { get; set; }

        //Outros
        public int Diretorio { get; set; }
        public string NomeClasse { get; set; }
        public int NumeroClasse { get; set; }
        public int PosicaoCabeloA = 20;
        public int PosicaoCabeloB = 24;
        public int PosicaoInfoDAT { get; set; }
    }
}
