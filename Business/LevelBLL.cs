using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using System.Configuration;
using System.IO;
using Util;

namespace Business
{
    public class LevelBLL
    {
        public Personagem Personagem { get; set; }

        //Construtor..
        public LevelBLL(Personagem personagem)
        {
            this.Personagem = personagem;
        }

        //Alterar o level do personagem..
        public bool Alterar(int Level)
        {
            try
            {
                //Verificando o level..
                if (this.Personagem.Level <= Level)
                {
                    //Carregando caminho do player..
                    string CaminhoNicknameChar = $@"{Funcoes.Caminho}\dataserver\userdata\{this.Personagem.Diretorio}\{this.Personagem.Nickname}.dat";

                    //Verificando se o .dat do player existe..
                    if (File.Exists(CaminhoNicknameChar))
                    {
                        string EXPLevel = Funcoes.XPHex(Level);
                        byte[] EXPLevel1 = new byte[4]; EXPLevel1[0] = (byte)Level;

                        //Convertendo o EXP -> decimal -> bytes
                        string DecimalLevel2 = EXPLevel.Substring(0, 4).ToString();
                        byte[] ByteDecimal1 = new byte[1]; ByteDecimal1[0] = (byte)Convert.ToInt32(DecimalLevel2[0].ToString() + DecimalLevel2[1].ToString(), 16); //405
                        byte[] ByteDecimal2 = new byte[1]; ByteDecimal2[0] = (byte)Convert.ToInt32(DecimalLevel2[2].ToString() + DecimalLevel2[3].ToString(), 16); //404
                        byte[] ByteDecimal3 = new byte[1]; ByteDecimal3[0] = (byte)0; //403
                        byte[] ByteDecimal4 = new byte[1]; ByteDecimal4[0] = (byte)0; //402

                        string DecimalLevel3 = EXPLevel.Substring(4, 8).ToString();
                        byte[] ByteDecimal5 = new byte[1]; ByteDecimal5[0] = (byte)Convert.ToInt32(DecimalLevel3[0].ToString() + DecimalLevel3[1].ToString(), 16); //335
                        byte[] ByteDecimal6 = new byte[1]; ByteDecimal6[0] = (byte)Convert.ToInt32(DecimalLevel3[2].ToString() + DecimalLevel3[3].ToString(), 16); //334
                        byte[] ByteDecimal7 = new byte[1]; ByteDecimal7[0] = (byte)Convert.ToInt32(DecimalLevel3[4].ToString() + DecimalLevel3[5].ToString(), 16); //333
                        byte[] ByteDecimal8 = new byte[1]; ByteDecimal8[0] = (byte)Convert.ToInt32(DecimalLevel3[6].ToString() + DecimalLevel3[7].ToString(), 16); //332

                        //Alterando level..
                        Funcoes.Alterar(CaminhoNicknameChar, byteAlteracao: EXPLevel1, posicao: 200);

                        Funcoes.Alterar(CaminhoNicknameChar, byteAlteracao: ByteDecimal1, posicao: 405);
                        Funcoes.Alterar(CaminhoNicknameChar, byteAlteracao: ByteDecimal2, posicao: 404);
                        Funcoes.Alterar(CaminhoNicknameChar, byteAlteracao: ByteDecimal3, posicao: 403);
                        Funcoes.Alterar(CaminhoNicknameChar, byteAlteracao: ByteDecimal4, posicao: 402);

                        Funcoes.Alterar(CaminhoNicknameChar, byteAlteracao: ByteDecimal5, posicao: 335);
                        Funcoes.Alterar(CaminhoNicknameChar, byteAlteracao: ByteDecimal6, posicao: 334);
                        Funcoes.Alterar(CaminhoNicknameChar, byteAlteracao: ByteDecimal7, posicao: 333);
                        Funcoes.Alterar(CaminhoNicknameChar, byteAlteracao: ByteDecimal8, posicao: 332);

                        //Level alterado com sucesso..
                        return true;
                    }
                    else
                    {
                        //Arquivo do player não foi encontrado..
                        return false;
                    }
                }
                else
                {
                    //Level menor que o level atual..
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
