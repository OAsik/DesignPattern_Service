using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XaPa.Framework.Data.Repository;
using XaPa.Service.Data.Infrastructure.DataContext;
using XaPa.Service.Data.Repository.RepositoryBase;
using XaPa.Service.Model.Entity.XaPa;

namespace XaPa.Service.Data.Repository.EntityRepository
{
    public class UserTitlesRepository : Repository<UserTitles>, IUserTitlesRepository
    {
        public UserTitlesRepository(XaPaDataContext context) : base(context)
        {

        }

        public XaPaDataContext XaPaDataContext
        {
            get { return Context as XaPaDataContext; }
        }
    }
}