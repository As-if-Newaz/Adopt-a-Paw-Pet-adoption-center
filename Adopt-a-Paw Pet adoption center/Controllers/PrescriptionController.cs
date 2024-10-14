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
    [Logged]
    [RoutePrefix("api/Prescription")]
    public class PrescriptionController : ApiController
    {
        [HttpGet]
        [Route("all")]

        public HttpResponseMessage Get()
        {
            try
            {
                var data = PrescriptionService.Get();
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
                var data = PrescriptionService.Get(Id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpPost]
        [Route("Create")]

        public HttpResponseMessage Create(PrescriptionDTO obj)
        {
            try
            {
                var data = PrescriptionService.Create(obj);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpPost]
        [Route("Update")]

        public HttpResponseMessage Update(PrescriptionDTO obj)
        {
            try
            {
                var data = PrescriptionService.Update(obj);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpGet]
        [Route("delete/{Id}")]

        public HttpResponseMessage Create(int Id)
        {
            try
            {
                var data = PrescriptionService.Delete(Id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
            }
        }
    }
}
