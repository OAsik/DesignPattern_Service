using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using XaPa.Service.Helper.Constants;
using XaPa.Service.Manager.BusinessManager;
using XaPa.Service.Model.WebModel;
using XaPa.Service.Project.API.Filter;

namespace XaPa.Service.Project.API.Controllers
{
    [IdentityBasicAuthentication]
    [Authorize]
    [Route("api/ProductOps")]
    public class ProductController : BaseController
    {
        ProductsManager _productsManager;

        public ProductController()
        {
            _productsManager = new ProductsManager();
        }

        [Route("ListProducts")]
        [HttpGet]
        public HttpResponseMessage GetAllProducts()
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, _productsManager.GetAllProducts());
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.ToString());
            }
        }

        [Route("ShortProducts/{id}")]
        [HttpGet]
        public HttpResponseMessage GetProductsOnLowStocks(int id)
        {
            try
            {
                if (string.IsNullOrEmpty(id.ToString()))
                {
                    throw new Exception(ErrorMessageConstants.StockAmountEmpty);
                }

                return Request.CreateResponse(HttpStatusCode.OK, _productsManager.FindProducts(x => x.UnitsInStock <= id));
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.ToString());
            }
        }

        [Route("InsertProduct")]
        public HttpResponseMessage AddNewProduct(NewProductWM webModel)
        {
            try
            {
                _productsManager.AddProduct(webModel);

                return Request.CreateResponse(HttpStatusCode.Created);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.ToString());
            }
        }

        [Route("ReduceQuantity")]
        public HttpResponseMessage ReduceSoldProduct(UpdateProductWM webModel)
        {
            try
            {
                var product = _productsManager.GetProduct(webModel.ProductID);

                if (product == null)
                {
                    throw new Exception(ErrorMessageConstants.ProductNotFound);
                }

                product.UnitsInStock = product.UnitsInStock - webModel.Quantity;

                if (product.UnitsInStock <= 0)
                {
                    throw new Exception(ErrorMessageConstants.MinusUnitsOnOrder);
                }

                product.UnitsOnOrder = product.UnitsOnOrder + webModel.Quantity;

                _productsManager.UpdateProduct(product);

                return Request.CreateResponse(HttpStatusCode.Created);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.ToString());
            }
        }

        [Route("IncreaseQuantity")]
        public HttpResponseMessage IncreaseProductQuantity(UpdateProductWM webModel)
        {
            try
            {
                var product = _productsManager.GetProduct(webModel.ProductID);

                if (product == null)
                {
                    throw new Exception(ErrorMessageConstants.ProductNotFound);
                }

                product.UnitsInStock = product.UnitsInStock + webModel.Quantity;

                _productsManager.UpdateProduct(product);

                return Request.CreateResponse(HttpStatusCode.Created);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.ToString());
            }
        }
    }
}