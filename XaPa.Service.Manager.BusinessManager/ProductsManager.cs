using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using XaPa.Service.Helper.Constants;
using XaPa.Service.Helper.Methods;
using XaPa.Service.Manager.Business.XaPaOperations;
using XaPa.Service.Mapper.Manager;
using XaPa.Service.Model.Entity.XaPa;
using XaPa.Service.Model.WebModel;

namespace XaPa.Service.Manager.BusinessManager
{
    public class ProductsManager : BaseManager
    {
        private readonly ProductsOperations _productsOperations;
        private readonly ProductImagesOperations _productImagesOperations;

        public ProductsManager()
        {
            _productsOperations = new ProductsOperations(base.IUOW);
            _productImagesOperations = new ProductImagesOperations(base.IUOW);
        }

        public ProductsWM GetProduct(int id)
        {
            try
            {
                return ProductsMapping.MaptoWM(_productsOperations.GetProduct(id));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public List<ProductsWM> GetAllProducts()
        {
            try
            {
                return ProductsMapping.MaptoWM(_productsOperations.GetAllProducts());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public List<ProductsWM> FindProducts(Expression<Func<Products, bool>> predicate)
        {
            try
            {
                return ProductsMapping.MaptoWM(_productsOperations.FindProducts(predicate));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public void AddProduct(NewProductWM webModel)
        {
            #region AddProductValidations
            List<AddProductValidationBase> validationList = new List<AddProductValidationBase>();
            validationList.Add(new CheckProductImagePath());
            validationList.Add(new CheckProductCategory());
            validationList.Add(new CheckProductName());
            validationList.Add(new CheckProductUnitPrice());

            validationList[0].SetNextValidation(validationList[1]);
            validationList[1].SetNextValidation(validationList[2]);
            validationList[2].SetNextValidation(validationList[3]);

            validationList[0].Execute(webModel);
            bool webModelValid = validationList[validationList.Count - 1].IsValid; 
            #endregion

            if (webModelValid)
            {
                try
                {
                    Bitmap image = new Bitmap(webModel.ImagePath);

                    ProductImages productImage = new ProductImages
                    {
                        ProductPicture = ImageToByteConverter.ConvertImagePath(image)
                    };

                    _productImagesOperations.AddProductImage(productImage);

                    _productsOperations.AddProduct(ProductsMapping.MapToEntity(webModel.Product));
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }
            }            
        }

        public void AddProducts(List<ProductsWM> webModelList)
        {
            try
            {
                _productsOperations.AddProducts(ProductsMapping.MapToEntity(webModelList));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public void DeleteProduct(ProductsWM webModel)
        {
            try
            {
                _productsOperations.DeleteProduct(ProductsMapping.MapToEntity(webModel));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public void DeteleProducts(List<ProductsWM> webModelList)
        {
            try
            {
                _productsOperations.DeleteProducts(ProductsMapping.MapToEntity(webModelList));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public void UpdateProduct(ProductsWM webModel)
        {
            try
            {
                _productsOperations.UpdateProduct(ProductsMapping.MapToEntity(webModel));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
    }
}