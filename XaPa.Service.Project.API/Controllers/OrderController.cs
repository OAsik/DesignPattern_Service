using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using XaPa.Service.Manager.BusinessManager;
using XaPa.Service.Project.API.Filter;

namespace XaPa.Service.Project.API.Controllers
{
    [IdentityBasicAuthentication]
    [Authorize]
    [Route("api/OrderOps")]
    public class OrderController : BaseController
    {
        OrdersManager _ordersManager;

        public OrderController()
        {
            _ordersManager = new OrdersManager();
        }

        [Route("FindMyOrders")]
        [HttpGet]
        public HttpResponseMessage RetrieveUsersOrder()
        {
            try
            {
                var user = GetCurrentUser();

                return Request.CreateResponse(HttpStatusCode.OK, _ordersManager.FindOrders(x => x.UserID == user.UserID).OrderBy(x => x.OrderDate));
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.ToString());
            }
        }
    }
}