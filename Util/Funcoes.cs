using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using System.Configuration;

namespace Util
{
    public static class Funcoes
    {
        public static string Caminho = ConfigurationManager.AppSettings["CaminhoServidor"];

        //Acha o número da pasta por login/nick.
        public static int Diretorio(string d)
        {
            int pasta = 0;
            for (int p = 0; p < d.Length; p++)
            {
                pasta = pasta + (int)Convert.ToChar(d.Substring(p, 1).ToUpper());
                if (pasta >= 256)
                    pasta = pasta - 256;
            }
            return pasta;
        }

        //Completa string com espaço vazio.
        public static string AddVazio(int qtdAdd, string valor)
        {
            string addOnLeft = string.Empty;
            int leftLen = (qtdAdd - valor.Length);
            for (int i = 0; i < leftLen; i++)
            {
                addOnLeft += "\x00";
            }
            return addOnLeft;
        }

        //Retorna os bytes do arquivo .dat
        public static byte[] BytesDAT(string fullFilePath)
        {
            FileStream fs = File.OpenRead(fullFilePath);
            try
            {
                byte[] bytes = new byte[fs.Length];
                fs.Read(bytes, 0, Convert.ToInt32(fs.Length));
                fs.Close();
                return bytes;
            }
            finally
            {
                fs.Close();
            }
        }

        //Alterar arquivo .dat
        public static void Alterar(string caminho, byte[] byteAlteracao, int posicao)
        {
            int contador = 0;
            byte[] bytesOriginal = BytesDAT(caminho);
            using (FileStream fileStream = new FileStream(caminho, FileMode.Create))
            {
                for (int i = 0; i < bytesOriginal.Length; i++)
                {
                    if ((i >= posicao) && (i < (posicao + byteAlteracao.Length)))
                    {
                        fileStream.WriteByte(byteAlteracao[contador]);
                        contador++;
                    }
                    else
                    {
                        fileStream.WriteByte(bytesOriginal[i]);
                    }
                }
            }
        }

        //Retorna o EXP da do level
        public static string XPHex(int level)
        {
            string EXP = string.Empty;
            string[] Linhas = File.ReadAllLines($@"{ConfigurationManager.AppSettings["CaminhoServidor"]}\XPHex.txt");
            EXP = Linhas[level - 1];
            return EXP;
        }

        //Retorna o total de pontos (status) do level do player
        public static int TotalPontosStatus(int level)
        {
            int retorno = 0;
            for (int i = 2; i <= level; i++)
            {
                if (i <= 70)
                {
                    retorno = retorno + 5;
                }
                else if ((i > 70) && (i <= 90))
                {
                    retorno = retorno + 7;
                }
                else
                {
                    retorno = retorno + 10;
                }
            }
            return retorno;
        }

        //Formatando status
        public static int FormatarStatus(int status1, int status2)
        {
            //toString('X2') = Convertendo binario para hex..
            //ToInt32(16) = Convertendo hex para decimal..
            return Convert.ToInt32(status2.ToString("X2") + status1.ToString("X2"), 16);
        }

        //Formata status
        public static byte[] FormatarStatus(string hex)
        {
            byte[] retorno = new byte[2];
            if (hex.Length > 2)
            {
                retorno[0] = (byte)Convert.ToInt32(hex.Substring(1, 2).ToString(), 16);
                retorno[1] = (byte)Convert.ToInt32(hex.Substring(0, 1).ToString(), 16);
            }
            else
            {
                retorno[0] = (byte)Convert.ToInt32(hex.Substring(0, hex.Length).ToString(), 16);
                retorno[1] = 0;
            }
            return retorno;
        }

        //Carrega pontos status.
        public static int CarregaPontosStatus(Status s, int level, int novosStatus = 99)
        {
            int retorno;
            //Carregando total de pontos distribuidos..
            int totalPontosDistribuidos = (s.Forca + s.Inteligencia + s.Talento + s.Agilidade + s.Vitalidade) - novosStatus;

            //Descontando do total de pontos para esse level..
            if (novosStatus > 0)
            {
                retorno = (TotalPontosStatus(level) - totalPontosDistribuidos);
            }
            else
            {
                retorno = totalPontosDistribuidos;
            }

            if (retorno < 0)
                retorno = 0;

            return retorno;
        }

        //Carrega total de pontos magias
        public static int TotalPontosMagia(int level, string tipo)
        {
            int SP = ((level - 10) / 2) + 1;
            int EP = ((level - 60) / 2) + 1;

            if (level >= 55) SP = SP + 1;
            if (level >= 70) SP = SP + 1;
            if (level >= 80) SP = SP + 2;

            return (tipo.ToUpper() == "SP") ? SP : EP;
        }
    }
}
