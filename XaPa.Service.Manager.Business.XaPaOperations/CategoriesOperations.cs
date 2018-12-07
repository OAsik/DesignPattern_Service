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
    public class CategoriesOperations
    {
        private readonly IUnitOfWork _uow;

        public CategoriesOperations(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public Categories GetCategory(int id)
        {
            try
            {
                Categories category = _uow.Categories.Get(id);
                _uow.Complete();
                return category;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public List<Categories> GetAllCategories()
        {
            try
            {
                List<Categories> categoryList = _uow.Categories.GetAll().ToList();
                _uow.Complete();
                return categoryList;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public List<Categories> FindCategories(Expression<Func<Categories, bool>> predicate)
        {
            try
            {
                List<Categories> categoryList = _uow.Categories.Find(predicate).ToList();
                _uow.Complete();
                return categoryList;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public void AddCategory(Categories entity)
        {
            try
            {
                _uow.Categories.Add(entity);
                _uow.Complete();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public void AddCategories(List<Categories> entityList)
        {
            try
            {
                _uow.Categories.AddRange(entityList);
                _uow.Complete();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public void DeleteCategory(Categories entity)
        {
            try
            {
                _uow.Categories.Remove(entity);
                _uow.Complete();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public void DeleteCategories(List<Categories> entityList)
        {
            try
            {
                _uow.Categories.RemoveRange(entityList);
                _uow.Complete();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public void UpdateCategory(Categories entity)
        {
            try
            {
                _uow.Categories.Update(entity);
                _uow.Complete();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
    }
}