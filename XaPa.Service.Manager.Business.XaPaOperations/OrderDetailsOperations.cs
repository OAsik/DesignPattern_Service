using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using XaPa.Service.Data.UnitOfWork.Infrastructure;
using XaPa.Service.Model.Entity.XaPa;
using XaPa.Service.Model.WebModel;

namespace XaPa.Service.Manager.Business.XaPaOperations
{
    public class OrderDetailsOperations
    {
        private readonly IUnitOfWork _uow;

        public OrderDetailsOperations(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public OrderDetails GetOrderDetail(int id)
        {
            try
            {
                OrderDetails orderDetail = _uow.OrderDetails.Get(id);
                _uow.Complete();
                return orderDetail;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public List<OrderDetails> GetAllOrderDetails()
        {
            try
            {
                List<OrderDetails> orderDetailList = _uow.OrderDetails.GetAll().ToList();
                _uow.Complete();
                return orderDetailList;
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
                return _uow.OrderDetails.FindOrderDetail(predicate);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public List<OrderDetails> FindOrderDetails(Expression<Func<OrderDetails, bool>> predicate)
        {
            try
            {
                List<OrderDetails> orderDetailList = _uow.OrderDetails.Find(predicate).ToList();
                _uow.Complete();
                return orderDetailList;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public void AddOrderDetail(OrderDetails entity)
        {
            try
            {
                _uow.OrderDetails.Add(entity);
                _uow.Complete();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public void AddOrderDetails(List<OrderDetails> entityList)
        {
            try
            {
                _uow.OrderDetails.AddRange(entityList);
                _uow.Complete();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public void DeleteOrderDetail(OrderDetails entity)
        {
            try
            {
                _uow.OrderDetails.Remove(entity);
                _uow.Complete();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public void DeleteOrderDetails(List<OrderDetails> entityList)
        {
            try
            {
                _uow.OrderDetails.RemoveRange(entityList);
                _uow.Complete();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public void UpdateOrderDetail(OrderDetails entity)
        {
            try
            {
                _uow.OrderDetails.Update(entity);
                _uow.Complete();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
    }
}