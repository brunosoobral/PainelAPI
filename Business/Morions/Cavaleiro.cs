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

    public class Cavaleiro : Personagem //--> Herança
    {
        //construtor default..
        public Cavaleiro()
        {
            //Identificação da classe.
            NomeClasse = "Knight";
            NumeroClasse = 6;

            //Carregando Cabelo
            CabeloA = @"char\tmABCD\ma001.ini";
            CabeloB = @"char\tmABCD\Mmh-A03.inf";

            //Carregando status (padrão)..
            Status = new Status();
            Status.Forca = 26;
            Status.Inteligencia = 13;
            Status.Talento = 17;
            Status.Agilidade = 19;
            Status.Vitalidade = 24;

            //Carregando nome das magias..
            //Tier 1
            Tier1 = new Magias[] {
                    new Magias { Valor = 1, Nome = "Sword Blast" },
                    new Magias { Valor = 1, Nome = "Holy Body" },
                    new Magias { Valor = 1, Nome = "Physical Training" },
                    new Magias { Valor = 1, Nome = "Double Crash" }
                };

            //Tier 2
            Tier2 = new Magias[] {
                    new Magias { Valor = 1, Nome = "Holy Valor" },
                    new Magias { Valor = 1, Nome = "Brandish" },
                    new Magias { Valor = 1, Nome = "Piercing" },
                    new Magias { Valor = 1, Nome = "Drastic Spirit" }
                };

            //Tier 3
            Tier3 = new Magias[] {
                    new Magias { Valor = 1, Nome = "Sword Mastery" },
                    new Magias { Valor = 1, Nome = "Devine Shield" },
                    new Magias { Valor = 1, Nome = "Holy Incantation" },
                    new Magias { Valor = 1, Nome = "Grand Cross" }
                };

            //Tier 4
            Tier4 = new Magias[] {
                    new Magias { Valor = 1, Nome = "Sword Of Justice" },
                    new Magias { Valor = 1, Nome = "Godly Shield" },
                    new Magias { Valor = 1, Nome = "God's Blessing" },
                    new Magias { Valor = 1, Nome = "Divine Piercing" }
                };
        }
    }
}
