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
    /*-----------------------------------------
        Autor:      Bruno Sobral                  
        Skype:      bruno.soobral
        E-mail:     bruno.soobral@gmail.com
    -----------------------------------------*/

    public class PersonagemBLL
    {
        private Usuario Usuario { get; set; }

        public PersonagemBLL(Usuario usuario)
        {
            this.Usuario = usuario;
            this.Usuario.Diretorio = Funcoes.Diretorio(usuario.Login);
        }

        //Criando personagem..
        public string Criar(Personagem p)
        {
            //Carregando caminho do player..
            string Login = this.Usuario.Login + Funcoes.AddVazio(10, this.Usuario.Login);
            string Nickname = p.Nickname + Funcoes.AddVazio(15, p.Nickname);

            //Carregando número do diretório..
            p.Diretorio = Funcoes.Diretorio(p.Nickname);

            //Caminhos
            string CaminhoDATs = AppDomain.CurrentDomain.BaseDirectory.Replace(@"\bin\Debug\", "");
            string CaminhoNovoNickInfo = $@"{Funcoes.Caminho}\dataserver\userinfo\{this.Usuario.Diretorio}\{this.Usuario.Login}.dat";
            string CaminhoNovoNicknameChar = $@"{Funcoes.Caminho}\dataserver\userdata\{p.Diretorio}\{p.Nickname}.dat";

            //Verificando se existe o arquivo .info desse login.
            if (!File.Exists(CaminhoNovoNickInfo))
            {
                //Criando arquivo na pasta do player.
                File.Copy($@"{CaminhoDATs}\Dats\info.dat", CaminhoNovoNickInfo);

                //Escrevendo login no arquivo info
                byte[] LoginBytes = new UTF8Encoding(true).GetBytes(Login);
                Funcoes.Alterar(CaminhoNovoNickInfo, byteAlteracao: LoginBytes, posicao: 16);
            }

            //Verificando se o nickname escolhido está em uso.
            if (!File.Exists(CaminhoNovoNicknameChar))
            {
                //Listando todos os nicks vinculados no login.
                Personagem[] Nicks = ListarNicks();

                //Verificando a quantidade de nicks
                int Quantidade = (from c in Nicks
                                  where (!string.IsNullOrWhiteSpace(c.Nickname))
                                  select c).Count();

                //Verificando a quantidade.
                if (Quantidade < 5)
                {
                    foreach (Personagem Nick in Nicks)
                    {
                        if (string.IsNullOrWhiteSpace(Nick.Nickname))
                        {
                            //Copiando o arquivo chat.dat
                            File.Copy($@"{CaminhoDATs}\Dats\char.dat", CaminhoNovoNicknameChar);

                            //Escrevendo login/nick no arquivo info e char.
                            byte[] LoginBytes = new UTF8Encoding(true).GetBytes(Login);
                            byte[] NickBytes = new UTF8Encoding(true).GetBytes(Nickname);
                            Funcoes.Alterar(CaminhoNovoNickInfo, byteAlteracao: NickBytes, posicao: Nick.PosicaoInfoDAT);
                            Funcoes.Alterar(CaminhoNovoNicknameChar, byteAlteracao: NickBytes, posicao: 16);
                            Funcoes.Alterar(CaminhoNovoNicknameChar, byteAlteracao: LoginBytes, posicao: 704);

                            //Instânciando o novo personagem..
                            p = Carregar(p);

                            //Alterando level inicial..
                            if (int.Parse(ConfigurationManager.AppSettings["AlteraLevelInicial"]) == 1)
                            {
                                var levelBLL = new LevelBLL(p);
                                levelBLL.Alterar(int.Parse(ConfigurationManager.AppSettings["LevelInicial"]));
                                p = Carregar(p);
                            }

                            //Alterando classe..
                            var ClasseBLL = new ClasseBLL(p);
                            var Classe = New(p.NumeroClasse); //Carregando nova classe..
                            ClasseBLL.Alterar(Classe);

                            //Alterar status..
                            var StatusBLL = new StatusBLL(p);
                            var Status = New(p.NumeroClasse).Status; //Carregando status da nova classe..
                            StatusBLL.Alterar(Status);

                            //Resetando magias..
                            var MagiasBLL = new MagiasBLL(p);
                            var Tier1 = New(p.NumeroClasse).Tier1;
                            var Tier2 = New(p.NumeroClasse).Tier2;
                            var Tier3 = New(p.NumeroClasse).Tier3;
                            var Tier4 = New(p.NumeroClasse).Tier4;
                            MagiasBLL.Alterar(Tier1, Tier2, Tier3, Tier4);

                            //Saindo do foreach..
                            break;
                        }
                    }

                    return "Sucesso: Personagem criado.";
                }
                else
                {
                    return "Erro: Você possui 5 personagens em sua conta.";
                }
            }
            else
            {
                return "Erro: Nickname escolhido está em uso.";
            }
        }

        //Excluir personagem..
        public string Excluir(string nickname)
        {
            try
            {
                //Caminhos
                string CaminhoNickInfo = $@"{Funcoes.Caminho}\dataserver\userinfo\{this.Usuario.Diretorio}\{this.Usuario.Login}.dat";
                string CaminhoNicknameChar = $@"{Funcoes.Caminho}\dataserver\userdata\{Funcoes.Diretorio(nickname)}\{nickname}.dat";
                string CaminhoDeleteNicknameChar = $@"{Funcoes.Caminho}\dataserver\deleted\EXCLUIDO_{nickname}.dat";

                //Verificando se o caminho existe..
                if (!File.Exists(CaminhoNicknameChar))
                {
                    return "Erro : Esse personagem não existe.";
                }

                //Listando todos os nicks dos personagens..
                Personagem[] Nicks = ListarNicks();

                //Varrendo os personagens..
                foreach (Personagem Personagem in Nicks)
                {
                    //Verificando o personagem preenchdio..
                    if (!string.IsNullOrWhiteSpace(Personagem.Nickname))
                    {
                        //Verificando se é o personagem que devemos excluir..
                        if (Personagem.Nickname.Trim('\x00').ToLower().Equals(nickname.Trim('\x00').ToLower()))
                        {
                            //Removendo nickname do arquivo info.
                            byte[] NickBytes = new UTF8Encoding(true).GetBytes(Funcoes.AddVazio(15, ""));
                            Funcoes.Alterar(CaminhoNickInfo, byteAlteracao: NickBytes, posicao: Personagem.PosicaoInfoDAT);

                            //Deletando o ultimo log do personagem..
                            if (File.Exists(CaminhoDeleteNicknameChar))
                                File.Delete(CaminhoDeleteNicknameChar);

                            //Gerando backup do arquivo char.
                            if (File.Exists(CaminhoNicknameChar))
                                File.Move(CaminhoNicknameChar, CaminhoDeleteNicknameChar);

                            break;
                        }
                    }
                }

                //Mensagem de sucesso..
                return "Personagem exluído com sucesso.";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return "Erro: Não foi possível excluir o personagem.";
            }
        }

        //Recriar personagem..
        public string Recriar(string nickname)
        {
            try
            {
                //Caminhos
                string CaminhoDATs = AppDomain.CurrentDomain.BaseDirectory.Replace(@"\bin\Debug\", "");
                string CaminhoNickInfo = $@"{Funcoes.Caminho}\dataserver\userinfo\{this.Usuario.Diretorio}\{this.Usuario.Login}.dat";
                string CaminhoNicknameChar = $@"{Funcoes.Caminho}\dataserver\userdata\{Funcoes.Diretorio(nickname)}\{nickname}.dat";
                string CaminhoDeleteNicknameChar = $@"{Funcoes.Caminho}\dataserver\deleted\EXCLUIDO_{nickname}.dat";

                //Verificando caminho do char.
                if (File.Exists(CaminhoNicknameChar))
                {
                    //Formatando login e nick para gravar no dat..
                    string Login = this.Usuario.Login + Funcoes.AddVazio(10, this.Usuario.Login);
                    string Nickname = nickname + Funcoes.AddVazio(15, nickname);

                    var p = GetPersonagem(nickname)[0];

                    //Verificando se o player já recriou alguma vez (se sim, vamos deletar o antigo)
                    if (File.Exists(CaminhoDeleteNicknameChar))
                        File.Delete(CaminhoDeleteNicknameChar);

                    //Gerando backup do arquivo char.
                    File.Move(CaminhoNicknameChar, CaminhoDeleteNicknameChar);

                    //Criando novo arquivo char.
                    File.Copy($@"{CaminhoDATs}\DATs\char.dat", CaminhoNicknameChar);

                    //Escrevendo login/nick no arquivo info e char.
                    byte[] LoginBytes = new UTF8Encoding(true).GetBytes(Login);
                    byte[] NickBytes = new UTF8Encoding(true).GetBytes(Nickname);
                    Funcoes.Alterar(CaminhoNicknameChar, byteAlteracao: NickBytes, posicao: 16);
                    Funcoes.Alterar(CaminhoNicknameChar, byteAlteracao: LoginBytes, posicao: 704);

                    //Alterando classe..
                    var ClasseBLL = new ClasseBLL(p);
                    var Classe = New(p.NumeroClasse); //Carregando nova classe..
                    ClasseBLL.Alterar(Classe);

                    //Alterando level..
                    var LevelBLL = new LevelBLL(p);
                    LevelBLL.Alterar(p.Level);

                    //Alterar status..
                    var StatusBLL = new StatusBLL(p);
                    var Status = p.Status; //Carregando status da nova classe..
                    StatusBLL.Alterar(Status);

                    //Resetando magias..
                    var MagiasBLL = new MagiasBLL(p);
                    MagiasBLL.Alterar(p.Tier1, p.Tier2, p.Tier3, p.Tier4);
                }

                return "Personagem recriado com sucesso.";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return "Erro: Não foi possível recriar o personagem.";
            }
        }

        //Retornando personagem..
        public Personagem[] GetPersonagem(string nickname = null)
        {
            //Listando todos os nicks dos personagens..
            Personagem[] Nicks = ListarNicks();

            //Capturando um ou todos personagens..
            var Search = from p in Nicks
                         where (((string.IsNullOrEmpty(nickname)) && (!string.IsNullOrEmpty(p.Nickname))) || ((!string.IsNullOrEmpty(nickname)) && (!string.IsNullOrEmpty(p.Nickname)) && (p.Nickname.Equals(nickname))))
                         select p;

            //Carregando personagem..
            var Personagem = new List<Personagem>();
            foreach (Personagem p in Search)
            {
                //Carregando usuário..
                var personagem = Carregar(p);

                //Verificando se o usuário carregou..            
                if (personagem != null)
                {
                    //Inserindo na lista de usuários..
                    Personagem.Add(personagem);
                }
            }

            return Personagem.ToArray();
        }

        //Retornando usuario + personagens..
        public Usuario GetUsuario()
        {
            this.Usuario.Diretorio = Funcoes.Diretorio(this.Usuario.Login);
            this.Usuario.Personagens = GetPersonagem();
            return this.Usuario;
        }

        //Listando personagens..
        public Personagem[] ListarNicks()
        {
            //string CaminhoInfo = $@"{Funcoes.Caminho}\dataserver\userinfo\{login)}\{login}.dat";
            string CaminhoInfo = $@"{Funcoes.Caminho}\DataServer\userinfo\{Funcoes.Diretorio(this.Usuario.Login)}\{this.Usuario.Login}.dat";

            //Carregando bytes do DAT..
            string Array = Encoding.UTF8.GetString(Funcoes.BytesDAT(CaminhoInfo));

            //Retornando personagens..
            var Personagens = new Personagem[] {
                new Personagem { Login = this.Usuario.Login, PosicaoInfoDAT = 48, Nickname = Array.Substring(0x30, 15).Trim('\x00') },
                new Personagem { Login = this.Usuario.Login, PosicaoInfoDAT = 80, Nickname = Array.Substring(0x50, 15).Trim('\x00') },
                new Personagem { Login = this.Usuario.Login, PosicaoInfoDAT = 112, Nickname = Array.Substring(0x70, 15).Trim('\x00') },
                new Personagem { Login = this.Usuario.Login, PosicaoInfoDAT = 144, Nickname = Array.Substring(0x90, 15).Trim('\x00') },
                new Personagem { Login = this.Usuario.Login, PosicaoInfoDAT = 176, Nickname = Array.Substring(0xb0, 15).Trim('\x00') }
            };

            return Personagens;
        }

        private Personagem New(int Classe)
        {
            Personagem Personagem = null;

            //Verificando a classe do personagem..
            //Carregando atributos dos personagens..
            switch (Classe)
            {
                case 1:
                    Personagem = new Lutador();
                    break;

                case 2:
                    Personagem = new Mecanico();
                    break;

                case 3:
                    Personagem = new Arqueira();
                    break;

                case 4:
                    Personagem = new Pikeman();
                    break;

                case 5:
                    Personagem = new Atalanta();
                    break;

                case 6:
                    Personagem = new Cavaleiro();
                    break;

                case 7:
                    Personagem = new Mago();
                    break;

                case 8:
                    Personagem = new Prist();
                    break;
            }

            return Personagem;
        }

        private Personagem Carregar(Personagem p)
        {
            Personagem Personagem = null;

            //string CaminhoChar = $@"{Funcoes.Caminho}\dataserver\userdata\{f.Diretorio(Nick.Value)}\{Nick.Value}.dat";
            string CaminhoChar = $@"{Funcoes.Caminho}\DataServer\userdata\{Funcoes.Diretorio(p.Nickname)}\{p.Nickname}.dat";

            //Carregando bytes do DAT..
            byte[] BytesChar = Funcoes.BytesDAT(CaminhoChar);

            //Verificando se existe bytes no arquivo.
            if (BytesChar.Length > 0)
            {
                //Instânciando o personagem...
                int Classe = (p.NumeroClasse != 0) ? p.NumeroClasse : Convert.ToInt32((BytesChar[0xc4]));

                //Recebendo a classe..
                Personagem = New(Classe);

                //Carregando atributos..
                Personagem.Login = p.Login;
                Personagem.Nickname = p.Nickname;
                Personagem.Level = Convert.ToInt32(BytesChar[0xc8]);
                Personagem.Diretorio = Funcoes.Diretorio(p.Nickname);
                Personagem.PosicaoInfoDAT = p.PosicaoInfoDAT;

                //Carregando status..
                Personagem.Status.Forca = Funcoes.FormatarStatus(BytesChar[0xcc], BytesChar[0xcd]);
                Personagem.Status.Inteligencia = Funcoes.FormatarStatus(BytesChar[0xd0], BytesChar[0xd1]);
                Personagem.Status.Talento = Funcoes.FormatarStatus(BytesChar[0xd4], BytesChar[0xd5]);
                Personagem.Status.Agilidade = Funcoes.FormatarStatus(BytesChar[0xd8], BytesChar[0xd9]);
                Personagem.Status.Vitalidade = Funcoes.FormatarStatus(BytesChar[0xdc], BytesChar[0xdd]);
                Personagem.Status.Pontos = Funcoes.CarregaPontosStatus(Personagem.Status, Personagem.Level);

                //Carregando magias..
                //Tier 1
                Personagem.Tier1[0].Valor = BytesChar[0x1fd];
                Personagem.Tier1[1].Valor = BytesChar[0x1fe];
                Personagem.Tier1[2].Valor = BytesChar[0x1ff];
                Personagem.Tier1[3].Valor = BytesChar[0x200];

                //Tier 2
                Personagem.Tier2[0].Valor = BytesChar[0x201];
                Personagem.Tier2[1].Valor = BytesChar[0x202];
                Personagem.Tier2[2].Valor = BytesChar[0x203];
                Personagem.Tier2[3].Valor = BytesChar[0x204];

                //Tier 3
                Personagem.Tier3[0].Valor = BytesChar[0x205];
                Personagem.Tier3[1].Valor = BytesChar[0x206];
                Personagem.Tier3[2].Valor = BytesChar[0x207];
                Personagem.Tier3[3].Valor = BytesChar[0x208];

                //Tier 4
                Personagem.Tier4[0].Valor = BytesChar[0x209];
                Personagem.Tier4[1].Valor = BytesChar[0x20A];
                Personagem.Tier4[2].Valor = BytesChar[0x20B];
                Personagem.Tier4[3].Valor = BytesChar[0x1fc];

                //Somando valores das magias.
                var QtdTier1 = Personagem.Tier1.Sum(t => Convert.ToInt32(t.Valor));
                var QtdTier2 = Personagem.Tier2.Sum(t => Convert.ToInt32(t.Valor));
                var QtdTier3 = Personagem.Tier3.Sum(t => Convert.ToInt32(t.Valor));
                var QtdTier4 = Personagem.Tier4.Sum(t => Convert.ToInt32(t.Valor));

                //Tier1 até Tier3 (A distribuir)
                int TotalPontosDisponivelSP = Funcoes.TotalPontosMagia(Personagem.Level, "SP");
                Personagem.PontosRestanteSP = (TotalPontosDisponivelSP - (QtdTier1 + QtdTier2 + QtdTier3));

                //Tier4 (A distribuir)
                int TotalPontosDisponivelEP = Funcoes.TotalPontosMagia(Personagem.Level, "EP");
                Personagem.PontosRestanteEP = (TotalPontosDisponivelEP - QtdTier4);

                //Carregando clan do usuário..
                //Criar no repositório..
            }

            return Personagem;
        }
    }
}
