using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Owin.Security.OAuth;
using System.Threading.Tasks;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using Entities;
using Business;

namespace Services
{
    public class Token : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            //context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });
            try
            {
                //Recebendo dados e montando objeto usuário..
                var u = new Usuario();
                u.Login = context.UserName;
                u.Senha = context.Password;

                //Validando os dados no banco..
                var bll = new UsuarioBLL();
                u = bll.ValidarLogin(u);

                //Validando os dados..
                if (u == null)
                {
                    context.SetError("invalid_grant", "Dados inválidos ou usuário bloqueado");
                    return;
                }

                var identity = new ClaimsIdentity(context.Options.AuthenticationType);
                identity.AddClaim(new Claim(ClaimTypes.Name, u.Login));

                var roles = new List<string>();
                roles.Add("Player");

                foreach (var role in roles)
                {
                    identity.AddClaim(new Claim(ClaimTypes.Role, role));
                }

                GenericPrincipal principal = new GenericPrincipal(identity, roles.ToArray());
                Thread.CurrentPrincipal = principal;

                context.Validated(identity);
            }
            catch
            {
                context.SetError("invalid_grant", "Falha ao autenticar");
            }
        }
    }
}