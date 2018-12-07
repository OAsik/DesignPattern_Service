using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XaPa.Service.Model.Entity.XaPa;
using XaPa.Service.Model.WebModel;

namespace XaPa.Service.Mapper.Manager
{
    public class CategoriesMapping
    {
        public static List<CategoriesWM> MaptoWM(List<Categories> entityList)
        {
            return entityList.Select(x => new CategoriesWM
            {
                CategoryID = x.CategoryID,
                CategoryName = x.CategoryName                
            }).ToList();
        }

        public static CategoriesWM MaptoWM(Categories entity)
        {
            return new CategoriesWM()
            {
                CategoryID = entity.CategoryID,
                CategoryName = entity.CategoryName
            };
        }

        public static List<Categories> MapToEntity(List<CategoriesWM> webModelList)
        {
            return webModelList.Select(x => new Categories
            {
                CategoryID = x.CategoryID,
                CategoryName = x.CategoryName
            }).ToList();
        }

        public static Categories MapToEntity(CategoriesWM webModel)
        {
            return new Categories()
            {
                CategoryID = webModel.CategoryID,
                CategoryName = webModel.CategoryName
            };
        }
    }
}