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

    public class Mecanico : Personagem //--> Herança
    {
        //construtor default..
        public Mecanico()
        {
            //Identificação da classe.
            NomeClasse = "Mechanician";
            NumeroClasse = 2;

            //Carregando cabelo..
            CabeloA = @"char\tmABCD\a001.ini";
            CabeloB = @"char\tmABCD\tmh-a02.inf";

            //Carregando status (padrão)..
            Status = new Status();
            Status.Forca = 24;
            Status.Inteligencia = 8;
            Status.Talento = 25;
            Status.Agilidade = 18;
            Status.Vitalidade = 24;

            //Carregando nome das magias..
            //Tier 1
            Tier1 = new Magias[] {
                    new Magias { Valor = 1, Nome = "Extreme Shield" },
                    new Magias { Valor = 1, Nome = "Mechanic Bomb" },
                    new Magias { Valor = 1, Nome = "Poison Attribute" },
                    new Magias { Valor = 1, Nome = "Physical Absorbtion" }
                };

            //Tier 2
            Tier2 = new Magias[] {
                    new Magias { Valor = 1, Nome = "Great Smash" },
                    new Magias { Valor = 1, Nome = "Maximize" },
                    new Magias { Valor = 1, Nome = "Automation" },
                    new Magias { Valor = 1, Nome = "Spark" }
                };

            //Tier 3
            Tier3 = new Magias[] {
                    new Magias { Valor = 1, Nome = "Metal Armor" },
                    new Magias { Valor = 1, Nome = "Grand Smash" },
                    new Magias { Valor = 1, Nome = "Mechanic Mastery" },
                    new Magias { Valor = 1, Nome = "Spark Shield" }
                };

            //Tier 4
            Tier4 = new Magias[] {
                    new Magias { Valor = 1, Nome = "Impulsion" },
                    new Magias { Valor = 1, Nome = "Compulsion" },
                    new Magias { Valor = 1, Nome = "Magnetic Sphere" },
                    new Magias { Valor = 1, Nome = "Metal Golem" }
                };
        }
    }
}
