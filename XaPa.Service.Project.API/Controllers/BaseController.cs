using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web;
using System.Web.Http;
using XaPa.Service.Manager.BusinessManager;
using XaPa.Service.Model.WebModel;

namespace XaPa.Service.Project.API.Controllers
{
    public class BaseController : ApiController
    {
        public UsersWM GetCurrentUser()
        {
            var identity = HttpContext.Current.User.Identity as ClaimsIdentity;

            try
            {
                return new UsersManager().IdentifyUser(identity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
    }
}