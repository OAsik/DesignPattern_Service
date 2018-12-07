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
    public class ProductsOperations
    {
        private readonly IUnitOfWork _uow;

        public ProductsOperations(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public Products GetProduct(int id)
        {
            try
            {
                Products product = _uow.Products.Get(id);
                _uow.Complete();
                return product;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public List<Products> GetAllProducts()
        {
            try
            {
                List<Products> productList = _uow.Products.GetAll().ToList();
                _uow.Complete();
                return productList;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public List<Products> FindProducts(Expression<Func<Products, bool>> predicate)
        {
            try
            {
                List<Products> productList = _uow.Products.Find(predicate).ToList();
                _uow.Complete();
                return productList;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public void AddProduct(Products entity)
        {
            try
            {
                _uow.Products.Add(entity);
                _uow.Complete();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public void AddProducts(List<Products> entityList)
        {
            try
            {
                _uow.Products.AddRange(entityList);
                _uow.Complete();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public void DeleteProduct(Products entity)
        {
            try
            {
                _uow.Products.Remove(entity);
                _uow.Complete();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public void DeleteProducts(List<Products> entityList)
        {
            try
            {
                _uow.Products.RemoveRange(entityList);
                _uow.Complete();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public void UpdateProduct(Products entity)
        {
            try
            {
                _uow.Products.Update(entity);
                _uow.Complete();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
    }
}