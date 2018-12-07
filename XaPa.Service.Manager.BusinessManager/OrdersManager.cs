using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using XaPa.Service.Manager.Business.XaPaOperations;
using XaPa.Service.Mapper.Manager;
using XaPa.Service.Model.Entity.XaPa;
using XaPa.Service.Model.WebModel;

namespace XaPa.Service.Manager.BusinessManager
{
    public class OrdersManager : BaseManager
    {
        private readonly OrdersOperations _ordersOperations;

        public OrdersManager()
        {
            _ordersOperations = new OrdersOperations(base.IUOW);
        }

        public OrdersWM GetOrder(int id)
        {
            try
            {
                return OrdersMapping.MaptoWM(_ordersOperations.GetOrder(id));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public List<OrdersWM> GetAllOrders()
        {
            try
            {
                return OrdersMapping.MaptoWM(_ordersOperations.GetAllOrders());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public List<OrdersWM> FindOrders(Expression<Func<Orders, bool>> predicate)
        {
            try
            {
                return OrdersMapping.MaptoWM(_ordersOperations.FindOrders(predicate));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public void AddOrder(OrdersWM webModel)
        {
            try
            {
                _ordersOperations.AddOrder(OrdersMapping.MapToEntity(webModel));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public void AddOrders(List<OrdersWM> webModelList)
        {
            try
            {
                _ordersOperations.AddOrders(OrdersMapping.MapToEntity(webModelList));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public void DeleteOrder(OrdersWM webModel)
        {
            try
            {
                _ordersOperations.DeleteOrder(OrdersMapping.MapToEntity(webModel));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public void DeteleOrders(List<OrdersWM> webModelList)
        {
            try
            {
                _ordersOperations.DeleteOrders(OrdersMapping.MapToEntity(webModelList));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public void UpdateOrder(OrdersWM webModel)
        {
            try
            {
                _ordersOperations.UpdateOrder(OrdersMapping.MapToEntity(webModel));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
    }
}