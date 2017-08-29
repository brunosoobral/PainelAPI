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

    public class Pikeman : Personagem //--> Herança
    {
        //construtor default..
        public Pikeman()
        {
            //Identificação da classe.
            NomeClasse = "Pikeman";
            NumeroClasse = 4;

            //Carregando Cabelo
            CabeloA = @"char\tmABCD\c001.ini";
            CabeloB = @"char\tmABCD\tmh-c02.inf";

            //Carregando status (padrão)..
            Status = new Status();
            Status.Forca = 26;
            Status.Inteligencia = 9;
            Status.Talento = 20;
            Status.Agilidade = 19;
            Status.Vitalidade = 25;

            //Carregando nome das magias..
            //Tier 1
            Tier1 = new Magias[] {
                    new Magias { Valor = 1, Nome = "Pike Wind" },
                    new Magias { Valor = 1, Nome = "Ice Attriute" },
                    new Magias { Valor = 1, Nome = "Critical Hit" },
                    new Magias { Valor = 1, Nome = "Jumping Crash" }
                };

            //Tier 2
            Tier2 = new Magias[] {
                    new Magias { Valor = 1, Nome = "Ground Pike" },
                    new Magias { Valor = 1, Nome = "Tornado" },
                    new Magias { Valor = 1, Nome = "Block Mastery" },
                    new Magias { Valor = 1, Nome = "Expansion" }
                };

            //Tier 3
            Tier3 = new Magias[] {
                    new Magias { Valor = 1, Nome = "Venom Spear" },
                    new Magias { Valor = 1, Nome = "Vanish" },
                    new Magias { Valor = 1, Nome = "Critical Mastery" },
                    new Magias { Valor = 1, Nome = "Chain Lance" }
                };

            //Tier 4
            Tier4 = new Magias[] {
                    new Magias { Valor = 1, Nome = "Assasin's Eye" },
                    new Magias { Valor = 1, Nome = "Charging Strike" },
                    new Magias { Valor = 1, Nome = "Vague" },
                    new Magias { Valor = 1, Nome = "Shadow Master" }
                };
        }
    }
}
