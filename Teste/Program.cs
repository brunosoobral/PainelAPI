using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Business;

namespace Teste
{
    class Program
    {
        static void Main(string[] args)
        {
            var u = new Usuario();
            u.Login = "Admin";

            //var bll = new PersonagemBLL(usuario: u);

            ////Listar usuário + personagens..
            //u = bll.GetUsuario();

            ////Carregando um personagem..           
            //Personagem Personagem = bll.GetPersonagem("Funcionou2")[0];
            ////Console.WriteLine(Personagem.Nickname);

            ////Carregando todos os personagens..
            //Personagem[] Personagens = bll.GetPersonagem();
            //foreach (Personagem p in Personagens)
            //{
            //    Console.WriteLine(p.Nickname);
            //}

            Console.ReadKey();
        }
    }
}
