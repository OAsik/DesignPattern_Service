using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
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
    public class ProductImagesManager : BaseManager
    {
        private readonly ProductImagesOperations _productImagesOperations;

        public ProductImagesManager()
        {
            _productImagesOperations = new ProductImagesOperations(base.IUOW);
        }

        public ProductImagesWM GetProductImage(int id)
        {
            try
            {
                return ProductImagesMapping.MaptoWM(_productImagesOperations.GetProductImage(id));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public List<ProductImagesWM> GetAllProductImages()
        {
            try
            {
                return ProductImagesMapping.MaptoWM(_productImagesOperations.GetAllProductImages());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public List<ProductImagesWM> FindProductImages(Expression<Func<ProductImages, bool>> predicate)
        {
            try
            {
                return ProductImagesMapping.MaptoWM(_productImagesOperations.FindProductImages(predicate));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        private byte[] ImageConverter(Bitmap file)
        {
            MemoryStream ms = new MemoryStream();
            file.Save(ms, ImageFormat.Png);
            return ms.ToArray();
        }

        public void AddProductImage(string filePath)
        {
            try
            {
                ProductImagesWM webModel = new ProductImagesWM();

                Bitmap file = new Bitmap(filePath);
                webModel.ProductPicture = ImageConverter(file);

                _productImagesOperations.AddProductImage(ProductImagesMapping.MapToEntity(webModel));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public void AddProductImages(string[] filePaths)
        {
            try
            {
                List<ProductImagesWM> webModelList = new List<ProductImagesWM>();

                foreach (string path in filePaths)
                {
                    Bitmap file = new Bitmap(path);
                    webModelList.Add(new ProductImagesWM()
                    {
                        ProductPicture = ImageConverter(file)
                    });
                }

                _productImagesOperations.AddProductImages(ProductImagesMapping.MapToEntity(webModelList));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public void DeleteProductImage(ProductImagesWM webModel)
        {
            try
            {
                _productImagesOperations.DeleteProductImage(ProductImagesMapping.MapToEntity(webModel));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public void DeteleProductImages(List<ProductImagesWM> webModelList)
        {
            try
            {
                _productImagesOperations.DeleteProductImages(ProductImagesMapping.MapToEntity(webModelList));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public void UpdateProductImage(ProductImagesWM webModel)
        {
            try
            {
                _productImagesOperations.UpdateProductImage(ProductImagesMapping.MapToEntity(webModel));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
    }
}