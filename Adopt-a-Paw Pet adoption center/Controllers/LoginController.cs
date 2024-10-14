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
    public class LoginController : ApiController
    {
        /*[HttpPost]
        [Route("api/login")]
        public HttpResponseMessage Login(LoginDTO obj)
        {
            try
            {
                var data = AuthService.Authentication(obj.Email, obj.Password);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }*/
    }
}
