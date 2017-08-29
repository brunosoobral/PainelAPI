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

    public class Atalanta : Personagem //--> Herança
    {
        //construtor default..
        public Atalanta()
        {
            //Identificação da classe.
            NomeClasse = "Atalanta";
            NumeroClasse = 5;

            //Carregando Cabelo
            CabeloA = @"char\tmABCD\mb001.ini";
            CabeloB = @"char\tmABCD\Mfh-B02.inf";

            //Carregando status (padrão)..
            Status = new Status();
            Status.Forca = 23;
            Status.Inteligencia = 15;
            Status.Talento = 19;
            Status.Agilidade = 19;
            Status.Vitalidade = 23;

            //Carregando nome das magias..
            //Tier 1
            Tier1 = new Magias[] {
                    new Magias { Valor = 1, Nome = "Shield Strike" },
                    new Magias { Valor = 1, Nome = "Farina" },
                    new Magias { Valor = 1, Nome = "Throwing Mastery" },
                    new Magias { Valor = 1, Nome = "Vigor Spear" }
                };

            //Tier 2
            Tier2 = new Magias[] {
                    new Magias { Valor = 1, Nome = "Windy" },
                    new Magias { Valor = 1, Nome = "Twisted Javelin" },
                    new Magias { Valor = 1, Nome = "Soul Sucker" },
                    new Magias { Valor = 1, Nome = "Fire Javelin" }
                };

            //Tier 3
            Tier3 = new Magias[] {
                    new Magias { Valor = 1, Nome = "Split Javelin" },
                    new Magias { Valor = 1, Nome = "Trimph Of Valhalla" },
                    new Magias { Valor = 1, Nome = "Light Javelin" },
                    new Magias { Valor = 1, Nome = "Storm Javelin" }
                };

            //Tier 4
            Tier3 = new Magias[] {
                    new Magias { Valor = 1, Nome = "Hall Of Valhalla" },
                    new Magias { Valor = 1, Nome = "Extreme Rage" },
                    new Magias { Valor = 1, Nome = "Frost Javelin" },
                    new Magias { Valor = 1, Nome = "Vengeance" }
                };
        }
    }
}
