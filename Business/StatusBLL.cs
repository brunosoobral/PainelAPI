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
    public class StatusBLL
    {
        private Personagem Personagem { get; set; }

        //Construtor..
        public StatusBLL(Personagem personagem)
        {
            this.Personagem = personagem;
        }

        //Resetar status do player..
        public bool Alterar(Status status)
        {
            try
            {
                //Carregando caminho do player..
                string CaminhoNicknameChar = $@"{Funcoes.Caminho}\dataserver\userdata\{this.Personagem.Diretorio}\{this.Personagem.Nickname}.dat";

                //Verificando se foi informado algum status..
                if (status != null)
                {
                    //Verificando se o .dat do player existe..
                    if (File.Exists(CaminhoNicknameChar))
                    {
                        //Carregando a quantidade de status disponível para distribuir..
                        int TotalStatusAlteracao = (status.Forca + status.Inteligencia + status.Talento + status.Agilidade + status.Vitalidade);
                        int TotalStatusPlayer = Funcoes.TotalPontosStatus(this.Personagem.Level);

                        //Verificando se a quantidade de status inseridos é maior que a quantidade disponível..
                        if (TotalStatusAlteracao <= TotalStatusPlayer)
                        {
                            //Convertendo para Hexdecimal + Convertendo para bytes na função..
                            byte[] BytesForca = Funcoes.FormatarStatus(status.Forca.ToString("X"));
                            byte[] BytesInteligencia = Funcoes.FormatarStatus(status.Inteligencia.ToString("X"));
                            byte[] BytesTalento = Funcoes.FormatarStatus(status.Talento.ToString("X"));
                            byte[] BytesAgilidade = Funcoes.FormatarStatus(status.Agilidade.ToString("X"));
                            byte[] BytesVitalidade = Funcoes.FormatarStatus(status.Vitalidade.ToString("X"));

                            //Alterando status do player..
                            Funcoes.Alterar(CaminhoNicknameChar, byteAlteracao: BytesForca, posicao: 204);
                            Funcoes.Alterar(CaminhoNicknameChar, byteAlteracao: BytesInteligencia, posicao: 208);
                            Funcoes.Alterar(CaminhoNicknameChar, byteAlteracao: BytesTalento, posicao: 212);
                            Funcoes.Alterar(CaminhoNicknameChar, byteAlteracao: BytesAgilidade, posicao: 216);
                            Funcoes.Alterar(CaminhoNicknameChar, byteAlteracao: BytesVitalidade, posicao: 220);

                            //Status atualizado com sucesso.
                            return true;
                        }
                        else
                        {
                            //Não possui esse total de status para distribuir.
                            return false;
                        }
                    }
                    else
                    {
                        //Arquivo do player não foi encontrado..
                        return false;
                    }
                }
                else
                {
                    //Objeto status não foi encontrado..
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
