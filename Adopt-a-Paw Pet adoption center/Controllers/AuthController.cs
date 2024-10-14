using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Adopt_a_Paw_Pet_adoption_center.Controllers
{
    public class AuthController : ApiController
    {
        [HttpPost]
        [Route("api/login")]
        public HttpResponseMessage Login(LoginDTO obj)
        {
            try
            {
                var token = AuthService.Authentication(obj.Email, obj.Password);
                if(token!= null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "User has Logged in!");
                }
                return Request.CreateResponse(HttpStatusCode.Unauthorized, "No token found!");
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        [HttpGet]
        [Route("api/logout")]

        public HttpResponseMessage Logout()
        {
            try
            {
                var token = AuthService.LogoutToken(Request.Headers.Authorization.ToString());
                return Request.CreateResponse(HttpStatusCode.OK);
              
                
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "You might forgot to supply token");
            }
        }
    }
}

