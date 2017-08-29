using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Util;
using System.Configuration;
using System.IO;

namespace Business
{
    public class ClasseBLL
    {
        private Personagem Personagem { get; set; }

        //Construtor..
        public ClasseBLL(Personagem personagem)
        {
            this.Personagem = personagem;
        }

        //Alterando a classe do personagem..
        public bool Alterar(Personagem NovaClasse)
        {
            try
            {
                //Carregando caminho do player..
                string CaminhoNicknameChar = $@"{Funcoes.Caminho}\dataserver\userdata\{this.Personagem.Diretorio}\{this.Personagem.Nickname}.dat";

                //Verificando se o .dat do player existe..
                if (File.Exists(CaminhoNicknameChar))
                {
                    //Gerando bytes dos dados..
                    byte[] ByteClasse = new byte[1]; ByteClasse[0] = (byte)NovaClasse.NumeroClasse;
                    byte[] BytesCabeloA = new UTF8Encoding(true).GetBytes(NovaClasse.CabeloA + Funcoes.AddVazio(NovaClasse.PosicaoCabeloA, NovaClasse.CabeloA));
                    byte[] BytesCabeloB = new UTF8Encoding(true).GetBytes(NovaClasse.CabeloB + Funcoes.AddVazio(NovaClasse.PosicaoCabeloB, NovaClasse.CabeloB));

                    Funcoes.Alterar(CaminhoNicknameChar, byteAlteracao: ByteClasse, posicao: 196);
                    Funcoes.Alterar(CaminhoNicknameChar, byteAlteracao: BytesCabeloA, posicao: 48);
                    Funcoes.Alterar(CaminhoNicknameChar, byteAlteracao: BytesCabeloB, posicao: 112);

                    //Retornando sucesso..
                    return true;
                }
                else
                {
                    //Arquivo do player não foi encontrado..
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
