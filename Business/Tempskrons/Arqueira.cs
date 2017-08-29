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

    public class Arqueira : Personagem //--> Herança
    {
        //construtor default..
        public Arqueira()
        {
            //Identificação da classe.
            NomeClasse = "Archer";
            NumeroClasse = 3;

            //CarregandoCabelo
            CabeloA = @"char\tmABCD\d001.ini";
            CabeloB = @"char\tmABCD\tfh-D01.inf";

            //Carregando status (padrão)..
            Status = new Status();
            Status.Forca = 17;
            Status.Inteligencia = 11;
            Status.Talento = 21;
            Status.Agilidade = 27;
            Status.Vitalidade = 23;

            //Carregando nome das magias..
            //Tier 1
            Tier1 = new Magias[] {
                    new Magias { Valor = 1, Nome = "Scout Hawk" },
                    new Magias { Valor = 1, Nome = "Shooting Mastery" },
                    new Magias { Valor = 1, Nome = "Wind Arrow" },
                    new Magias { Valor = 1, Nome = "Perfect Aim" }
                };

            //Tier 2
            Tier2 = new Magias[] {
                    new Magias { Valor = 1, Nome = "Dion's Eye" },
                    new Magias { Valor = 1, Nome = "Falcon" },
                    new Magias { Valor = 1, Nome = "Arrow Of Rage" },
                    new Magias { Valor = 1, Nome = "Avalanche" }
                };

            //Tier 3
            Tier3 = new Magias[] {
                    new Magias { Valor = 1, Nome = "Elemental Shot" },
                    new Magias { Valor = 1, Nome = "Golden Falcon" },
                    new Magias { Valor = 1, Nome = "Bomb Shot" },
                    new Magias { Valor = 1, Nome = "Perforation" }
                };

            //Tier 4
            Tier4 = new Magias[] {
                    new Magias { Valor = 1, Nome = "Wolverine" },
                    new Magias { Valor = 1, Nome = "Evasion Master" },
                    new Magias { Valor = 1, Nome = "Phoenix Shot" },
                    new Magias { Valor = 1, Nome = "Force Of Nature" }
                };
        }
    }
}
