using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XaPa.Service.Model.Entity.XaPa;
using XaPa.Service.Model.WebModel;

namespace XaPa.Service.Mapper.Manager
{
    public class OrdersMapping
    {
        public static List<OrdersWM> MaptoWM(List<Orders> entityList)
        {
            return entityList.Select(x => new OrdersWM
            {
                OrderID = x.OrderID,
                UserID = x.UserID,
                OrderDate = x.OrderDate          
            }).ToList();
        }

        public static OrdersWM MaptoWM(Orders entity)
        {
            return new OrdersWM()
            {
                OrderID = entity.OrderID,
                UserID = entity.UserID,
                OrderDate = entity.OrderDate
            };
        }

        public static List<Orders> MapToEntity(List<OrdersWM> webModelList)
        {
            return webModelList.Select(x => new Orders
            {
                OrderID = x.OrderID,
                UserID = x.UserID,
                OrderDate = x.OrderDate
            }).ToList();
        }

        public static Orders MapToEntity(OrdersWM webModel)
        {
            return new Orders()
            {
                OrderID = webModel.OrderID,
                UserID = webModel.UserID,
                OrderDate = webModel.OrderDate
            };
        }
    }
}