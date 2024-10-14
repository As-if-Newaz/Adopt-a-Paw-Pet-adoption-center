using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Adopt_a_Paw_Pet_adoption_center.Auth
{
    public class Logged : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            var auth = actionContext.Request.Headers.Authorization;
            if (auth == null)
            {
                actionContext.Response = actionContext.Request.CreateErrorResponse(System.Net.HttpStatusCode.Unauthorized, "No token found!");
            }
            else if(!AuthService.IsTokenValid(auth.ToString()))
            {
                actionContext.Response = actionContext.Request.CreateErrorResponse(System.Net.HttpStatusCode.Unauthorized, "Supplied Token is expired or invalid");
            }
            base.OnAuthorization(actionContext);
        }
    }
}