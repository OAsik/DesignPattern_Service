using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XaPa.Service.Data.Infrastructure.DataContext;
using XaPa.Service.Data.Repository.EntityRepository;
using XaPa.Service.Data.Repository.RepositoryBase;
using XaPa.Service.Data.UnitOfWork.Infrastructure;

namespace XaPa.Service.Data.UnitOfWork.XaPa
{
    public class XaPaUnitOfWork : IUnitOfWork
    {
        private readonly XaPaDataContext _context;

        public XaPaUnitOfWork(XaPaDataContext context)
        {
            _context = context;
            Categories = new CategoriesRepository(_context);
            OrderDetails = new OrderDetailsRepository(_context);
            Orders = new OrdersRepository(_context);
            ProductImages = new ProductImagesRepository(_context);
            Products = new ProductsRepository(_context);
            Users = new UsersRepository(_context);
            UserTitles = new UserTitlesRepository(_context);
            UserTokens = new UserTokensRepository(_context);
        }

        public ICategoriesRepository Categories { get; private set; }
        public IOrderDetailsRepository OrderDetails { get; private set; }
        public IOrdersRepository Orders { get; private set; }
        public IProductImagesRepository ProductImages { get; private set; }
        public IProductsRepository Products { get; private set; }
        public IUsersRepository Users { get; private set; }
        public IUserTitlesRepository UserTitles { get; private set; }
        public IUserTokensRepository UserTokens { get; private set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}