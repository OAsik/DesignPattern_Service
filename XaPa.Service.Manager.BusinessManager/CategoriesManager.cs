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
    public class CategoriesManager : BaseManager
    {
        private readonly CategoriesOperations _categoriesOperations;

        public CategoriesManager()
        {
            _categoriesOperations = new CategoriesOperations(base.IUOW);
        }

        public CategoriesWM GetCategory(int id)
        {
            try
            {
                return CategoriesMapping.MaptoWM(_categoriesOperations.GetCategory(id));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public List<CategoriesWM> GetAllCategories()
        {
            try
            {
                return CategoriesMapping.MaptoWM(_categoriesOperations.GetAllCategories());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public List<CategoriesWM> FindCategories(Expression<Func<Categories, bool>> predicate)
        {
            try
            {
                return CategoriesMapping.MaptoWM(_categoriesOperations.FindCategories(predicate));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public void AddCategory(CategoriesWM webModel)
        {
            try
            {
                _categoriesOperations.AddCategory(CategoriesMapping.MapToEntity(webModel));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public void AddCategories(List<CategoriesWM> webModelList)
        {
            try
            {
                _categoriesOperations.AddCategories(CategoriesMapping.MapToEntity(webModelList));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public void DeleteCategory(CategoriesWM webModel)
        {
            try
            {
                _categoriesOperations.DeleteCategory(CategoriesMapping.MapToEntity(webModel));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public void DeteleCategories(List<CategoriesWM> webModelList)
        {
            try
            {
                _categoriesOperations.DeleteCategories(CategoriesMapping.MapToEntity(webModelList));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public void UpdateCategory(CategoriesWM webModel)
        {
            try
            {
                _categoriesOperations.UpdateCategory(CategoriesMapping.MapToEntity(webModel));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
    }
}