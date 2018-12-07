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
    [Route("api/OrderDetailOps")]
    public class OrderDetailController : BaseController
    {
        OrderDetailsManager _orderDetailsManager;

        public OrderDetailController()
        {
            _orderDetailsManager = new OrderDetailsManager();
        }

        [Route("SeeMyOrderDetail/{id}")]
        [HttpGet]
        public HttpResponseMessage RetrieveUsersOrderDetail(int id)
        {
            try
            {
                if (string.IsNullOrEmpty(id.ToString()))
                {
                    throw new Exception(ErrorMessageConstants.UsersOrderDetailIDNotFound);
                }

                return Request.CreateResponse(HttpStatusCode.OK, _orderDetailsManager.FindOrderDetail(x => x.OrderDetailID == id));
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.ToString());
            }
        }
    }
}