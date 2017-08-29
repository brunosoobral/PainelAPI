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
    public class UsuarioDAL : Conexoes, IUsuario
    {
        public Usuario ObterPorLoginSenha(Usuario u)
        {
            try
            {
                //Abrindo conexão com banco de dados..
                Conectar();

                //Montando query..
                var query = new StringBuilder();
                query.Append($"Select * From {u.Login.Substring(0, 1).ToUpper()}GameUser ");
                query.Append("Where UserId = @Login And Passwd = @Senha And BlockChk = 0");

                //Executando a query no banco de dados..
                cmd = new SqlCommand(query.ToString(), con);
                cmd.Parameters.AddWithValue("@Login", u.Login);
                cmd.Parameters.AddWithValue("@Senha", u.Senha);
                dr = cmd.ExecuteReader();

                //Verificando os dados..
                if (!dr.Read())
                {
                    //Dados inválidos ou usuário bloqueado..
                    u = null;
                }

                //Retornando dados do usuário..
                return u;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            finally
            {
                Fechar();
            }
        }
    }
}
