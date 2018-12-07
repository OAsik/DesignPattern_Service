using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XaPa.Framework.Data.Repository.EntityFramework;
using XaPa.Service.Model.Entity.XaPa;

namespace XaPa.Service.Data.Repository.RepositoryBase
{
    public interface IUserTokensRepository : IRepository<UserTokens>
    {
        string PublishToken(string userName, string password, int epireTime, int notBeforeTime);
    }
}