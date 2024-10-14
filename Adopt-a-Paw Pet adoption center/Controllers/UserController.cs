using Adopt_a_Paw_Pet_adoption_center.Auth;
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
    
    [RoutePrefix("api/User")]
    public class UserController : ApiController
    {
        [HttpGet]
        [Route("all")]

        public HttpResponseMessage Get()
        {
            try
            {
                var data = UserService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpGet]
        [Route("{Id}")]

        public HttpResponseMessage Get(int Id)
        {
            try
            {
                var data = UserService.Get(Id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpPost]
        [Route("Create")]

        public HttpResponseMessage Create(UserDTO obj)
        {
            try
            {
                var data = UserService.Create(obj);
                if(data == true )
                {
                    return Request.CreateResponse(HttpStatusCode.OK, data);
                }
                else 
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, "Email already exists in database");
                }
                
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpPost]
        [Route("Update")]

        public HttpResponseMessage Update(UserDTO obj)
        {
            try
            {
                var data = UserService.Update(obj);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpGet]
        [Route("delete/{Id}")]

        public HttpResponseMessage Delete(int Id)
        {
            try
            {
                var data = UserService.Delete(Id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpGet]
        [Route("Validate/{Authkey}")]

        public HttpResponseMessage Validate(string Authkey)
        {
            try
            {
                var data = UserService.Validate(Authkey);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
            }
        }
    }
}
