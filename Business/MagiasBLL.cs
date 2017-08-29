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
    public class MagiasBLL
    {
        private Personagem Personagem { get; set; }

        //Construtor..
        public MagiasBLL(Personagem personagem)
        {
            this.Personagem = personagem;
        }

        //Resetar status do player..
        public bool Alterar(Magias[] Tier1, Magias[] Tier2, Magias[] Tier3, Magias[] Tier4)
        {
            try
            {
                //Carregando caminho do player..
                string CaminhoNicknameChar = $@"{Funcoes.Caminho}\dataserver\userdata\{this.Personagem.Diretorio}\{this.Personagem.Nickname}.dat";

                //Verificando se o .dat do player existe..
                if (File.Exists(CaminhoNicknameChar))
                {
                    //Somando valores das magias.
                    var QtdTier1 = Tier1.Sum(t => Convert.ToInt32(t.Valor));
                    var QtdTier2 = Tier2.Sum(t => Convert.ToInt32(t.Valor));
                    var QtdTier3 = Tier3.Sum(t => Convert.ToInt32(t.Valor));
                    var QtdTier4 = Tier4.Sum(t => Convert.ToInt32(t.Valor));

                    //Tier1 até Tier3 (A distribuir)
                    int TotalNovosPontosDisponivelSP = Funcoes.TotalPontosMagia(this.Personagem.Level, "SP");
                    int TotalNovosPontosDistribuidosSP = (QtdTier1 + QtdTier2 + QtdTier3);

                    //Tier4 (A distribuir)
                    int TotalNovosPontosDisponivelEP = Funcoes.TotalPontosMagia(this.Personagem.Level, "EP");
                    int TotalNovosPontosDistribuidosEP = QtdTier4;

                    //Verificando se a quantidade de pontos é maior que o permitido.
                    if (TotalNovosPontosDistribuidosSP > TotalNovosPontosDisponivelSP)
                    {
                        //Erro: Você enviou uma SP ({TotalNovosPontosDistribuidosSP}) que é maior que a SP permitida com ({TotalNovosPontosDisponivelSP}).
                        return false;
                    }

                    //Verificando se a quantidade de pontos é maior que o permitido.
                    if (TotalNovosPontosDistribuidosEP > TotalNovosPontosDisponivelEP)
                    {
                        //Erro: Você enviou uma EP ({TotalNovosPontosDistribuidosEP}) que é maior que a EP permitida com ({TotalNovosPontosDisponivelEP}).
                        return false;
                    }

                    //Alterando as magias..
                    int ContadorTier1 = 0;
                    foreach (Magias m in Tier1)
                    {
                        byte[] ByteAlterar = new byte[1]; ByteAlterar[0] = (byte)m.Valor;
                        Funcoes.Alterar(CaminhoNicknameChar, byteAlteracao: ByteAlterar, posicao: (509 + ContadorTier1));
                        ContadorTier1++;
                    }

                    int ContadorTier2 = 0;
                    foreach (Magias m in Tier2)
                    {
                        byte[] ByteAlterar = new byte[1]; ByteAlterar[0] = (byte)m.Valor;
                        Funcoes.Alterar(CaminhoNicknameChar, byteAlteracao: ByteAlterar, posicao: (513 + ContadorTier2));
                        ContadorTier2++;
                    }

                    int ContadorTier3 = 0;
                    foreach (Magias m in Tier3)
                    {
                        byte[] ByteAlterar = new byte[1]; ByteAlterar[0] = (byte)m.Valor;
                        Funcoes.Alterar(CaminhoNicknameChar, byteAlteracao: ByteAlterar, posicao: (517 + ContadorTier3));
                        ContadorTier3++;
                    }

                    int ContadorTier4 = 0;
                    foreach (Magias m in Tier4)
                    {
                        byte[] ByteAlterar = new byte[1]; ByteAlterar[0] = (byte)m.Valor;
                        Funcoes.Alterar(CaminhoNicknameChar, byteAlteracao: ByteAlterar, posicao: (521 + ContadorTier4));
                        if (ContadorTier4 < 2)
                        {
                            ContadorTier4++;
                        }
                        else
                        {
                            //Voltando 13 casas para alterar a ultima magia da tier 4.
                            ContadorTier4 = -13;
                        }
                    }

                    //Magias atualizadas com sucesso.
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
