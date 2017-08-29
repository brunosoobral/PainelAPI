using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Persistence;
using Entities;

namespace Business
{
    /*-----------------------------------------
        Autor:      Bruno Sobral                  
        Skype:      bruno.soobral
        E-mail:     bruno.soobral@gmail.com
    -----------------------------------------*/

    public class UsuarioBLL
    {
        private UsuarioDAL dal { get; set; }

        //Construtor..
        public UsuarioBLL()
        {
            this.dal = new UsuarioDAL();
        }

        public Usuario ValidarLogin(Usuario u)
        {
            //Validando os dados do usuário..
            u = dal.ObterPorLoginSenha(u);

            //Retornando usuário..
            return u;
        }
    }
}
