using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Entities;
using Business;
using Services.Models;

namespace Services.Controllers
{
    /*-----------------------------------------
        Autor:      Bruno Sobral                  
        Skype:      bruno.soobral
        E-mail:     bruno.soobral@gmail.com
    -----------------------------------------*/

    [RoutePrefix("api/personagem")]
    public class PersonagemController : ApiController
    {
        [Route("criar")]
        [Authorize(Roles = "Player")]
        [HttpPost]
        public HttpResponseMessage CriarPersonagem(PersonagemModelCriar model)
        {
            try
            {
                //verificar se os dados da model passaram nas validações.. 
                if (model != null)
                {
                    //Montando objeto do usuário..
                    var u = new Usuario();
                    u.Login = User.Identity.Name;

                    if (!string.IsNullOrEmpty(u.Login))
                    {
                        //Montando o objeto personagem..
                        var p = new Personagem();
                        p.Nickname = model.Nickname;
                        p.NumeroClasse = model.Classe;

                        //Recebendo os dados desse usuário..
                        var bll = new PersonagemBLL(usuario: u);
                        var r = bll.Criar(p);

                        //retornar mensagem de sucesso.. 
                        return Request.CreateResponse(HttpStatusCode.OK, r);
                    }
                    else
                    {
                        //retornar erro.. HTTP 403 (Forbiden) 
                        return Request.CreateResponse(HttpStatusCode.Forbidden, "Informe os dados obrigatórios");
                    }
                }
                else
                {
                    //retornar erro.. HTTP 403 (Forbiden) 
                    return Request.CreateResponse(HttpStatusCode.Forbidden, "Informe os dados obrigatórios");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                //retornar erro.. HTTP 500 (InternalServerError) 
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Erro ao criar o persoangem.");
            }
        }

        [Route("excluir")]
        [Authorize(Roles = "Player")]
        [HttpPost]
        public HttpResponseMessage ExcluirPersonagem(PersonagemModelExcluir model)
        {
            try
            {
                //verificar se os dados da model passaram nas validações.. 
                if (model != null)
                {
                    //Montando objeto do usuário..
                    var u = new Usuario();
                    u.Login = User.Identity.Name;

                    if (!string.IsNullOrEmpty(u.Login))
                    {
                        //Recebendo os dados desse usuário..
                        var bll = new PersonagemBLL(usuario: u);
                        var p = bll.Excluir(model.Nickname);

                        //Verificando se o objeto foi carregado..
                        if (!string.IsNullOrEmpty(p))
                        {
                            //retornar mensagem de sucesso.. 
                            return Request.CreateResponse(HttpStatusCode.OK, p);
                        }
                        else
                        {
                            //retornar erro.. HTTP 403 (Forbiden) 
                            return Request.CreateResponse(HttpStatusCode.Forbidden, "Não foi possível excluir.");
                        }
                    }
                    else
                    {
                        //retornar erro.. HTTP 403 (Forbiden) 
                        return Request.CreateResponse(HttpStatusCode.Forbidden, "Não foi possível excluir.");
                    }
                }
                else
                {
                    //retornar erro.. HTTP 403 (Forbiden) 
                    return Request.CreateResponse(HttpStatusCode.Forbidden, "Informe os dados obrigatórios");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                //retornar erro.. HTTP 500 (InternalServerError) 
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Erro ao excluir o persoangem.");
            }
        }

        [Route("recriar")]
        [Authorize(Roles = "Player")]
        [HttpPost]
        public HttpResponseMessage RecriarPersonagem(PersonagemModelRecriar model)
        {
            try
            {
                //verificar se os dados da model passaram nas validações.. 
                if (model != null)
                {
                    //Montando objeto do usuário..
                    var u = new Usuario();
                    u.Login = User.Identity.Name;
                    if (!string.IsNullOrEmpty(u.Login))
                    {
                        //Recebendo os dados desse usuário..
                        var bll = new PersonagemBLL(usuario: u);
                        var p = bll.Recriar(model.Nickname);

                        //Verificando se o objeto foi carregado..
                        if (!string.IsNullOrEmpty(p))
                        {
                            //retornar mensagem de sucesso.. 
                            return Request.CreateResponse(HttpStatusCode.OK, p);
                        }
                        else
                        {
                            //retornar erro.. HTTP 403 (Forbiden) 
                            return Request.CreateResponse(HttpStatusCode.Forbidden, "Não foi possível recriar.");
                        }
                    }
                    else
                    {
                        //retornar erro.. HTTP 403 (Forbiden) 
                        return Request.CreateResponse(HttpStatusCode.Forbidden, "Não foi possível recriar.");
                    }
                }
                else
                {
                    //retornar erro.. HTTP 403 (Forbiden) 
                    return Request.CreateResponse(HttpStatusCode.Forbidden, "Informe os dados obrigatórios");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                //retornar erro.. HTTP 500 (InternalServerError) 
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Erro ao recriar o persoangem.");
            }
        }

        [Route("listar")]
        [Authorize(Roles = "Player")]
        [HttpGet]
        public HttpResponseMessage ListarPersonagem(string nickname = null)
        {
            try
            {
                //Montando objeto do usuário..
                var u = new Usuario();
                u.Login = User.Identity.Name;

                if (!string.IsNullOrEmpty(u.Login))
                {
                    //Recebendo os dados desse usuário..
                    var bll = new PersonagemBLL(usuario: u);
                    var p = bll.GetPersonagem(nickname);

                    //Verificando se o objeto foi carregado..
                    if (p != null)
                    {
                        //retornar mensagem de sucesso.. 
                        return Request.CreateResponse(HttpStatusCode.OK, p);
                    }
                    else
                    {
                        //retornar erro.. HTTP 403 (Forbiden) 
                        return Request.CreateResponse(HttpStatusCode.Forbidden, "Não foi possível listar.");
                    }
                }
                else
                {
                    //retornar erro.. HTTP 403 (Forbiden) 
                    return Request.CreateResponse(HttpStatusCode.Forbidden, "Não foi possível listar.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                //retornar erro.. HTTP 500 (InternalServerError) 
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Erro ao listar o persoangem.");
            }
        }

        [Route("listarnicks")]
        [Authorize(Roles = "Player")]
        [HttpGet]
        public HttpResponseMessage ListarNicks()
        {
            try
            {
                //Montando objeto do usuário..
                var u = new Usuario();
                u.Login = User.Identity.Name;

                if (!string.IsNullOrEmpty(u.Login))
                {
                    //Recebendo os dados desse usuário..
                    var bll = new PersonagemBLL(usuario: u);
                    Personagem[] Nicks = bll.ListarNicks();

                    //Verificando se o objeto foi carregado..
                    if (Nicks.Count() > 0)
                    {
                        //Removendo nicks vazios..
                        var n = from p in Nicks
                                where (!string.IsNullOrWhiteSpace(p.Nickname))
                                select p.Nickname;

                        //retornar mensagem de sucesso.. 
                        return Request.CreateResponse(HttpStatusCode.OK, n);
                    }
                    else
                    {
                        //retornar erro.. HTTP 403 (Forbiden) 
                        return Request.CreateResponse(HttpStatusCode.Forbidden, "Não foi possível listar.");
                    }
                }
                else
                {
                    //retornar erro.. HTTP 403 (Forbiden) 
                    return Request.CreateResponse(HttpStatusCode.Forbidden, "Não foi possível listar.");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                //retornar erro.. HTTP 500 (InternalServerError) 
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Erro ao listar o persoangem.");
            }
        }
    }
}
