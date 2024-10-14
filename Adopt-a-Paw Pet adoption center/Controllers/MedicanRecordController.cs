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
    [RoutePrefix("api/MedicalRecord")]
    public class MedicanRecordController : ApiController
    {
        [HttpGet]
        [Route("all")]

        public HttpResponseMessage Get()
        {
            try
            {
                var data = MedicalRecordService.Get();
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
                var data = MedicalRecordService.Get(Id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpPost]
        [Route("Create")]

        public HttpResponseMessage Create(MedicalRecordDTO obj)
        {
            try
            {
                var data = MedicalRecordService.Create(obj);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpPost]
        [Route("Update")]

        public HttpResponseMessage Update(MedicalRecordDTO obj)
        {
            try
            {
                var data = MedicalRecordService.Update(obj);
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
                var data = MedicalRecordService.Delete(Id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
            }
        }
    }
}
