using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using XaPa.Service.Data.UnitOfWork.Infrastructure;
using XaPa.Service.Model.Entity.XaPa;

namespace XaPa.Service.Manager.Business.XaPaOperations
{
    public class OrdersOperations
    {
        private readonly IUnitOfWork _uow;

        public OrdersOperations(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public Orders GetOrder(int id)
        {
            try
            {
                Orders order = _uow.Orders.Get(id);
                _uow.Complete();
                return order;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public List<Orders> GetAllOrders()
        {
            try
            {
                List<Orders> orderList = _uow.Orders.GetAll().ToList();
                _uow.Complete();
                return orderList;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public List<Orders> FindOrders(Expression<Func<Orders, bool>> predicate)
        {
            try
            {
                List<Orders> orderList = _uow.Orders.Find(predicate).ToList();
                _uow.Complete();
                return orderList;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public void AddOrder(Orders entity)
        {
            try
            {
                _uow.Orders.Add(entity);
                _uow.Complete();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public void AddOrders(List<Orders> entityList)
        {
            try
            {
                _uow.Orders.AddRange(entityList);
                _uow.Complete();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public void DeleteOrder(Orders entity)
        {
            try
            {
                _uow.Orders.Remove(entity);
                _uow.Complete();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public void DeleteOrders(List<Orders> entityList)
        {
            try
            {
                _uow.Orders.RemoveRange(entityList);
                _uow.Complete();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public void UpdateOrder(Orders entity)
        {
            try
            {
                _uow.Orders.Update(entity);
                _uow.Complete();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
    }
}