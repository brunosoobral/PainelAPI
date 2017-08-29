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

    public class Mago : Personagem //--> Herança
    {
        //construtor default..
        public Mago()
        {
            //Identificação da classe.
            NomeClasse = "Magician";
            NumeroClasse = 7;

            //Carregando Cabelo
            CabeloA = @"char\tmABCD\md001.ini";
            CabeloB = @"char\tmABCD\Mmh-D01.inf";

            //Carregando status (padrão)..
            Status = new Status();
            Status.Forca = 16;
            Status.Inteligencia = 29;
            Status.Talento = 19;
            Status.Agilidade = 14;
            Status.Vitalidade = 21;

            //Carregando nome das magias..
            //Tier 1
            Tier1 = new Magias[] {
                    new Magias { Valor = 1, Nome = "Agony" },
                    new Magias { Valor = 1, Nome = "Fire Bolt" },
                    new Magias { Valor = 1, Nome = "Zenith" },
                    new Magias { Valor = 1, Nome = "Fire Ball" }
                };

            //Tier 2
            Tier2 = new Magias[] {
                    new Magias { Valor = 1, Nome = "Mental Mastery" },
                    new Magias { Valor = 1, Nome = "Waternado" },
                    new Magias { Valor = 1, Nome = "Enchant Weapon" },
                    new Magias { Valor = 1, Nome = "Death Ray" }
                };

            //Tier 3
            Tier3 = new Magias[] {
                    new Magias { Valor = 1, Nome = "Enery Shield" },
                    new Magias { Valor = 1, Nome = "Diastrophism" },
                    new Magias { Valor = 1, Nome = "Spirit Elemental" },
                    new Magias { Valor = 1, Nome = "Dancing Sword" }
                };

            //Tier 4
            Tier4 = new Magias[] {
                    new Magias { Valor = 1, Nome = "Fire Elemental" },
                    new Magias { Valor = 1, Nome = "Flame Wave" },
                    new Magias { Valor = 1, Nome = "Distortion" },
                    new Magias { Valor = 1, Nome = "Meteorite" }
                };
        }
    }
}
