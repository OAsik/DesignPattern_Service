using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using XaPa.Framework.Data.Repository.EntityFramework;
using XaPa.Service.Model.Entity.XaPa;

namespace XaPa.Service.Data.Repository.RepositoryBase
{
    public interface IUsersRepository : IRepository<Users>
    {
        IQueryable<Users> FindUser(Expression<Func<Users, bool>> predicate);
        IQueryable<Users> IdentifyUser(ClaimsIdentity claimsIdentity);
    }
}