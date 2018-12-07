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
    public class OrderDetailsManager : BaseManager
    {
        private readonly OrderDetailsOperations _orderDetailsOperations;

        public OrderDetailsManager()
        {
            _orderDetailsOperations = new OrderDetailsOperations(base.IUOW);
        }

        public OrderDetailsWM GetOrderDetail(int id)
        {
            try
            {
                return OrderDetailsMapping.MapToWM(_orderDetailsOperations.GetOrderDetail(id));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public List<OrderDetailsWM> GetAllOrderDetails()
        {
            try
            {
                return OrderDetailsMapping.MapToWM(_orderDetailsOperations.GetAllOrderDetails());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public UsersOrderDetailWM FindOrderDetail(Expression<Func<OrderDetails, bool>> predicate)
        {
            try
            {
                return _orderDetailsOperations.FindOrderDetail(predicate);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public List<OrderDetailsWM> FindOrderDetails(Expression<Func<OrderDetails, bool>> predicate)
        {
            try
            {
                return OrderDetailsMapping.MapToWM(_orderDetailsOperations.FindOrderDetails(predicate));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public void AddOrderDetail(OrderDetailsWM webModel)
        {
            try
            {
                _orderDetailsOperations.AddOrderDetail(OrderDetailsMapping.MapToEntity(webModel));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public void AddOrderDetails(List<OrderDetailsWM> webModelList)
        {
            try
            {
                _orderDetailsOperations.AddOrderDetails(OrderDetailsMapping.MapToEntity(webModelList));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public void DeleteOrderDetail(OrderDetailsWM webModel)
        {
            try
            {
                _orderDetailsOperations.DeleteOrderDetail(OrderDetailsMapping.MapToEntity(webModel));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public void DeteleOrderDetails(List<OrderDetailsWM> webModelList)
        {
            try
            {
                _orderDetailsOperations.DeleteOrderDetails(OrderDetailsMapping.MapToEntity(webModelList));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public void UpdateOrderDetail(OrderDetailsWM webModel)
        {
            try
            {
                _orderDetailsOperations.UpdateOrderDetail(OrderDetailsMapping.MapToEntity(webModel));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
    }
}