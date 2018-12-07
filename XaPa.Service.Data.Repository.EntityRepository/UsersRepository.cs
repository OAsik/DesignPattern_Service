using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using XaPa.Framework.Data.Repository;
using XaPa.Service.Data.Infrastructure.DataContext;
using XaPa.Service.Data.Repository.RepositoryBase;
using XaPa.Service.Model.Entity.XaPa;

namespace XaPa.Service.Data.Repository.EntityRepository
{
    public class UsersRepository : Repository<Users>, IUsersRepository
    {
        public UsersRepository(XaPaDataContext context) : base(context)
        {

        }

        public IQueryable<Users> FindUser(Expression<Func<Users, bool>> predicate)
        {
            return XaPaDataContext.Users.Where(predicate);
        }

        public IQueryable<Users> IdentifyUser(ClaimsIdentity claimsIdentity)
        {
            string userEmail = "";
            string userPassword = "";

            if (claimsIdentity != null)
            {
                IEnumerable<Claim> claims = claimsIdentity.Claims;
                List<Claim> claimsArray = claims.ToList();
                string[] emailArray = claimsArray[0].ToString().Split(':');
                string emailValue = emailArray[2].ToString();
                userEmail = emailValue.Trim();
                string[] passwordArray = claimsArray[1].ToString().Split(':');
                string passwordValue = passwordArray[2].ToString();
                userPassword = passwordValue.Trim();
            }

            var user = FindUser(x => x.UserAppName == userEmail && x.UserPassword == userPassword);

            return user;
        }

        public XaPaDataContext XaPaDataContext
        {
            get { return Context as XaPaDataContext; }
        }

    }
}