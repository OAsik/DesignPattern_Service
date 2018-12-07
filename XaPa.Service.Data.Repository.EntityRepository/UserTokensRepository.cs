using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using XaPa.Framework.Data.Repository;
using XaPa.Service.Data.Infrastructure.DataContext;
using XaPa.Service.Data.Repository.RepositoryBase;
using XaPa.Service.Model.Entity.XaPa;

namespace XaPa.Service.Data.Repository.EntityRepository
{
    public class UserTokensRepository : Repository<UserTokens>, IUserTokensRepository
    {
        public UserTokensRepository(XaPaDataContext context) : base(context)
        {

        }

        public string PublishToken(string userName, string password, int epireTime, int notBeforeTime)
        {
            var hmac = new HMACSHA256();
            var key = Convert.ToBase64String(hmac.Key);
            var symmetricKey = Convert.FromBase64String(key);

            var tokenHandler = new JwtSecurityTokenHandler();

            var now = DateTime.Now;

            var tokenDescriptor = new Microsoft.IdentityModel.Tokens.SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Email, userName),
                    new Claim(ClaimTypes.Hash, password),
                }),
                NotBefore = now.AddMinutes(Convert.ToInt32(notBeforeTime)),
                Expires = now.AddMinutes(Convert.ToInt32(epireTime)),
                SigningCredentials = new Microsoft.IdentityModel.Tokens.SigningCredentials(new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(symmetricKey), Microsoft.IdentityModel.Tokens.SecurityAlgorithms.HmacSha256Signature)
            };

            var stoken = tokenHandler.CreateToken(tokenDescriptor);
            var token = tokenHandler.WriteToken(stoken);

            return token;
        }

        public XaPaDataContext XaPaDataContext
        {
            get { return Context as XaPaDataContext; }
        }
    }
}