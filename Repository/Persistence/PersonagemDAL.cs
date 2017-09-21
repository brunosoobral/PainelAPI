using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Repository.Interfaces;
using Repository.Settings;
using Entities;

namespace Repository.Persistence
{
    /*-----------------------------------------
        Autor:      Bruno Sobral                  
        Skype:      bruno.soobral
        E-mail:     bruno.soobral@gmail.com
    -----------------------------------------*/

    public class PersonagemDAL : Conexoes, IPersonagem
    {
        public string RetornaClan(Personagem p)
        {
            try
            {
                //Abrindo conexão com banco de dados..
                Conectar();

                //Executando a query no banco de dados..
                cmd = new SqlCommand("Select ClanName From ClanDb..Ul Where UserId = @UserId And ChName = @ChName", con);
                cmd.Parameters.AddWithValue("@UserId", p.Login);
                cmd.Parameters.AddWithValue("@ChName", p.Nickname);

                //Retornando clan do usuário..
                return cmd.ExecuteScalar().ToString();
            }
            catch
            {
                return string.Empty;
            }
            finally
            {
                Fechar();
            }
        }
    }
}
