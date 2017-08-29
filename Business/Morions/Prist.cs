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

    public class Prist : Personagem //--> Herança
    {
        //construtor default..
        public Prist()
        {
            //Identificação da classe.
            NomeClasse = "Priestess";
            NumeroClasse = 8;

            //Carregando Cabelo..
            CabeloA = @"char\tmABCD\mc001.ini";
            CabeloB = @"char\tmABCD\Mfh-C01.inf";

            //Carregando status (padrão)..
            Status = new Status();
            Status.Forca = 15;
            Status.Inteligencia = 28;
            Status.Talento = 21;
            Status.Agilidade = 15;
            Status.Vitalidade = 20;

            //Carregando nome das magias..
            //Tier 1
            Tier1 = new Magias[] {
                    new Magias { Valor = 1, Nome = "Healing" },
                    new Magias { Valor = 1, Nome = "Holy Bolt" },
                    new Magias { Valor = 1, Nome = "Multi Spark" },
                    new Magias { Valor = 1, Nome = "Holy Mind" }
                };

            //Tier 2
            Tier2 = new Magias[] {
                    new Magias { Valor = 1, Nome = "Meditation" },
                    new Magias { Valor = 1, Nome = "Divine Lightening" },
                    new Magias { Valor = 1, Nome = "Holy Reflection" },
                    new Magias { Valor = 1, Nome = "Grand Healing" }
                };

            //Tier 3
            Tier3 = new Magias[] {
                    new Magias { Valor = 1, Nome = "Vigor Ball" },
                    new Magias { Valor = 1, Nome = "Resurrection" },
                    new Magias { Valor = 1, Nome = "Extinction" },
                    new Magias { Valor = 1, Nome = "Virtual Life" }
                };

            //Tier 4
            Tier4 = new Magias[] {
                    new Magias { Valor = 1, Nome = "Glacial Spike" },
                    new Magias { Valor = 1, Nome = "Regen Field" },
                    new Magias { Valor = 1, Nome = "Chain Lightening" },
                    new Magias { Valor = 1, Nome = "Summon Muspell" }
                };
        }
    }
}
