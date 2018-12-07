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
    public class ProductImagesOperations
    {
        private readonly IUnitOfWork _uow;

        public ProductImagesOperations(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public ProductImages GetProductImage(int id)
        {
            try
            {
                ProductImages image = _uow.ProductImages.Get(id);
                _uow.Complete();
                return image;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public List<ProductImages> GetAllProductImages()
        {
            try
            {
                List<ProductImages> imageList = _uow.ProductImages.GetAll().ToList();
                _uow.Complete();
                return imageList;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public List<ProductImages> FindProductImages(Expression<Func<ProductImages, bool>> predicate)
        {
            try
            {
                List<ProductImages> imageList = _uow.ProductImages.Find(predicate).ToList();
                _uow.Complete();
                return imageList;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public void AddProductImage(ProductImages entity)
        {
            try
            {
                _uow.ProductImages.Add(entity);
                _uow.Complete();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public void AddProductImages(List<ProductImages> entityList)
        {
            try
            {
                _uow.ProductImages.AddRange(entityList);
                _uow.Complete();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public void DeleteProductImage(ProductImages entity)
        {
            try
            {
                _uow.ProductImages.Remove(entity);
                _uow.Complete();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public void DeleteProductImages(List<ProductImages> entityList)
        {
            try
            {
                _uow.ProductImages.RemoveRange(entityList);
                _uow.Complete();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public void UpdateProductImage(ProductImages entity)
        {
            try
            {
                _uow.ProductImages.Update(entity);
                _uow.Complete();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
    }
}