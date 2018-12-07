using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using XaPa.Service.Helper.Constants;
using XaPa.Service.Manager.BusinessManager;
using XaPa.Service.Model.WebModel;

namespace XaPa.Service.Project.API.Controllers
{
    [Route("api/LoginRequest")]
    public class LoginController : BaseController
    {
        UserTokensManager _userTokensManager;

        public LoginController()
        {
            _userTokensManager = new UserTokensManager();
        }

        [Route("LoginToApp")]
        [HttpPost]
        public HttpResponseMessage Login(LoginWM webModel)
        {
            try
            {
                _userTokensManager.PublishToken(webModel.UserAppName, webModel.UserPassword, TokenConstants.TokenExpiryTime, TokenConstants.TokenNotBeforeTime);

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.ToString());
            }
        }
    }
}