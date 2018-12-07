using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using XaPa.Service.Manager.BusinessManager;
using XaPa.Service.Model.WebModel;

namespace XaPa.Service.Project.API.Filter
{
    public class IdentityBasicAuthenticationAttribute : JwtAuthenticationAttribute
    {
        protected override Task<IPrincipal> AuthenticateAsync(string userName, string password, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            UsersManager userManager = new UsersManager();
            UserTokensManager userTokenManager = new UserTokensManager();
            var user = userManager.FindUser(x => x.UserAppName == userName && x.UserPassword == password);

            if (userName != user.UserAppName && password != user.UserPassword)
            {
                return null;
            }

            Claim emailClaim = new Claim(ClaimTypes.Email, userName);
            Claim passwordClaim = new Claim(ClaimTypes.Hash, password);
            List<Claim> claims = new List<Claim> { emailClaim, passwordClaim };

            ClaimsIdentity identity = new ClaimsIdentity(claims, AuthenticationTypes.Basic);

            var principal = new ClaimsPrincipal(identity);
            return Task.FromResult<IPrincipal>(principal);
        }
    }
}