using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XaPa.Service.Model.Entity.XaPa;
using XaPa.Service.Model.WebModel;

namespace XaPa.Service.Mapper.Manager
{
    public class ProductsMapping
    {
        public static List<ProductsWM> MaptoWM(List<Products> entityList)
        {
            return entityList.Select(x => new ProductsWM
            {
                ProductID = x.ProductID,
                CategoryID = x.CategoryID,
                ProductName = x.ProductName,
                UnitPrice = x.UnitPrice,
                UnitsInStock = x.UnitsInStock,
                UnitsOnOrder = x.UnitsOnOrder
            }).ToList();
        }

        public static ProductsWM MaptoWM(Products entity)
        {
            return new ProductsWM()
            {
                ProductID = entity.ProductID,
                CategoryID = entity.CategoryID,
                ProductName = entity.ProductName,
                UnitPrice = entity.UnitPrice,
                UnitsInStock = entity.UnitsInStock,
                UnitsOnOrder = entity.UnitsOnOrder
            };
        }

        public static List<Products> MapToEntity(List<ProductsWM> webModelList)
        {
            return webModelList.Select(x => new Products
            {
                ProductID = x.ProductID,
                CategoryID = x.CategoryID,
                ProductName = x.ProductName,
                UnitPrice = x.UnitPrice,
                UnitsInStock = x.UnitsInStock,
                UnitsOnOrder = x.UnitsOnOrder
            }).ToList();
        }

        public static Products MapToEntity(ProductsWM webModel)
        {
            return new Products()
            {
                ProductID = webModel.ProductID,
                CategoryID = webModel.CategoryID,
                ProductName = webModel.ProductName,
                UnitPrice = webModel.UnitPrice,
                UnitsInStock = webModel.UnitsInStock,
                UnitsOnOrder = webModel.UnitsOnOrder
            };
        }
    }
}