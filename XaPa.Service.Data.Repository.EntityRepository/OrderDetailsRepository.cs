using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using XaPa.Framework.Data.Repository;
using XaPa.Service.Data.Infrastructure.DataContext;
using XaPa.Service.Data.Repository.RepositoryBase;
using XaPa.Service.Model.Entity.XaPa;
using XaPa.Service.Model.WebModel;

namespace XaPa.Service.Data.Repository.EntityRepository
{
    public class OrderDetailsRepository : Repository<OrderDetails>, IOrderDetailsRepository
    {
        public OrderDetailsRepository(XaPaDataContext context) : base(context)
        {

        }

        public UsersOrderDetailWM FindOrderDetail(Expression<Func<OrderDetails, bool>> predicate)
        {
            var data = XaPaDataContext.OrderDetails.Where(predicate).Include(x => x.Products);

            UsersOrderDetailWM webModel = new UsersOrderDetailWM
            {
                OrderDetailID = data.FirstOrDefault().OrderDetailID,
                ProductName = data.FirstOrDefault().Products.ProductName,
                Quantity = data.FirstOrDefault().Quantity
            };

            return webModel;
        }

        public XaPaDataContext XaPaDataContext
        {
            get { return Context as XaPaDataContext; }
        }
    }
}