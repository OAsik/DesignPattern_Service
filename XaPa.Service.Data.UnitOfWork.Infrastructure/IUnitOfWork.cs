using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XaPa.Service.Data.Repository.RepositoryBase;

namespace XaPa.Service.Data.UnitOfWork.Infrastructure
{
    public interface IUnitOfWork : IDisposable
    {
        ICategoriesRepository Categories { get; }
        IOrderDetailsRepository OrderDetails { get; }
        IOrdersRepository Orders { get; }
        IProductImagesRepository ProductImages { get; }
        IProductsRepository Products { get; }
        IUsersRepository Users { get; }
        IUserTitlesRepository UserTitles { get; }
        IUserTokensRepository UserTokens { get; }
        int Complete();
    }
}