using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XaPa.Service.Model.Entity.XaPa;
using XaPa.Service.Model.WebModel;

namespace XaPa.Service.Mapper.Manager
{
    public class ProductImagesMapping
    {
        public static List<ProductImagesWM> MaptoWM(List<ProductImages> entityList)
        {
            return entityList.Select(x => new ProductImagesWM
            {
                ProductImageID = x.ProductImageID,
                ProductPicture = x.ProductPicture
            }).ToList();
        }

        public static ProductImagesWM MaptoWM(ProductImages entity)
        {
            return new ProductImagesWM()
            {
                ProductImageID = entity.ProductImageID,
                ProductPicture = entity.ProductPicture
            };
        }

        public static List<ProductImages> MapToEntity(List<ProductImagesWM> webModelList)
        {
            return webModelList.Select(x => new ProductImages
            {
                ProductImageID = x.ProductImageID,
                ProductPicture = x.ProductPicture
            }).ToList();
        }

        public static ProductImages MapToEntity(ProductImagesWM webModel)
        {
            return new ProductImages()
            {
                ProductImageID = webModel.ProductImageID,
                ProductPicture = webModel.ProductPicture
            };
        }
    }
}