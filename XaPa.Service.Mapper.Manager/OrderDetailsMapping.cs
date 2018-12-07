using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XaPa.Service.Model.Entity.XaPa;
using XaPa.Service.Model.WebModel;

namespace XaPa.Service.Mapper.Manager
{
    public class OrderDetailsMapping
    {
        public static List<OrderDetailsWM> MapToWM(List<OrderDetails> entityList)
        {
            return entityList.Select(x => new OrderDetailsWM
            {
                OrderDetailID = x.OrderDetailID,
                ProductID = x.ProductID,
                Quantity = x.Quantity                
            }).ToList();
        }

        public static OrderDetailsWM MapToWM(OrderDetails entity)
        {
            return new OrderDetailsWM()
            {
                OrderDetailID = entity.OrderDetailID,
                ProductID = entity.ProductID,
                Quantity = entity.Quantity
            };
        }

        public static OrderDetailsWM MapToWM(IQueryable<OrderDetails> entity)
        {
            return new OrderDetailsWM()
            {
                OrderDetailID = entity.FirstOrDefault().OrderDetailID,
                ProductID = entity.FirstOrDefault().ProductID,
                Quantity = entity.FirstOrDefault().Quantity
            };
        }

        public static List<OrderDetails> MapToEntity(List<OrderDetailsWM> webModelList)
        {
            return webModelList.Select(x => new OrderDetails
            {
                OrderDetailID = x.OrderDetailID,
                ProductID = x.ProductID,
                Quantity = x.Quantity
            }).ToList();
        }

        public static OrderDetails MapToEntity(OrderDetailsWM webModel)
        {
            return new OrderDetails()
            {
                OrderDetailID = webModel.OrderDetailID,
                ProductID = webModel.ProductID,
                Quantity = webModel.Quantity
            };
        }
    }
}