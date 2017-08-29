using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Business
{
    /*-----------------------------------------
        Autor:      Bruno Sobral                  
        Skype:      bruno.soobral
        E-mail:     bruno.soobral@gmail.com
    -----------------------------------------*/

    public class Lutador : Personagem //--> Herança
    {
        //construtor default..
        public Lutador()
        {
            //Identificação da classe.
            NomeClasse = "Fighter";
            NumeroClasse = 1;

            //Carregando cabelo..
            CabeloA = @"char\tmABCD\b001.ini";
            CabeloB = @"char\tmABCD\tmh-b02.inf";

            //Carregando status (padrão)..
            Status = new Status();
            Status.Forca = 28;
            Status.Inteligencia = 6;
            Status.Talento = 21;
            Status.Agilidade = 17;
            Status.Vitalidade = 27;

            //Carregando nome das magias..
            //Tier 1
            Tier1 = new Magias[] {
                    new Magias { Valor = 1, Nome = "Meele Mastery" },
                    new Magias { Valor = 1, Nome = "Fire Attribute" },
                    new Magias { Valor = 1, Nome = "Raving" },
                    new Magias { Valor = 1, Nome = "Impact" }
                };

            //Tier 2
            Tier2 = new Magias[] {
                    new Magias { Valor = 1, Nome = "Tripple Impact" },
                    new Magias { Valor = 1, Nome = "Brutal Swing" },
                    new Magias { Valor = 1, Nome = "Roar" },
                    new Magias { Valor = 1, Nome = "Rage Zecram" }
                };

            //Tier 3
            Tier3 = new Magias[] {
                    new Magias { Valor = 1, Nome = "Concentration" },
                    new Magias { Valor = 1, Nome = "Avenging Crash" },
                    new Magias { Valor = 1, Nome = "Swift Axe" },
                    new Magias { Valor = 1, Nome = "Bone Crash" }
                };

            //Tier 4
            Tier4 = new Magias[] {
                    new Magias { Valor = 1, Nome = "Destroyer" },
                    new Magias { Valor = 1, Nome = "Berserker" },
                    new Magias { Valor = 1, Nome = "Cyclone Strike" },
                    new Magias { Valor = 1, Nome = "Boost Health" }
                };
        }
    }
}
