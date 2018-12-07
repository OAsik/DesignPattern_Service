using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using XaPa.Service.Helper.Constants;
using XaPa.Service.Manager.BusinessManager;
using XaPa.Service.Project.API.Filter;

namespace XaPa.Service.Project.API.Controllers
{
    [IdentityBasicAuthentication]
    [Authorize]
    [Route("api/RetrieveProductImages")]
    public class ProductImagesController : BaseController
    {
        ProductImagesManager _productImagesManager;

        public ProductImagesController()
        {
            _productImagesManager = new ProductImagesManager();
        }

        [Route("ProductsImage/{id}")]
        public HttpResponseMessage GetProductBinaryImage(int id)
        {
            try
            {
                if (string.IsNullOrEmpty(id.ToString()))
                {
                    throw new Exception(ErrorMessageConstants.ProductIDNotDefined);
                }

                return Request.CreateResponse(HttpStatusCode.OK, _productImagesManager.GetProductImage(id));
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.ToString());
            }
        }
    }
}