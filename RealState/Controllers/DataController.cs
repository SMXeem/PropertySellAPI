using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RealState.Models;

namespace RealState.Controllers
{
    /// <summary>
    /// Get Enum
    /// </summary>
    public class DataController : ApiController
    {
        private readonly RealStateEntities _aRealStateEntities = new RealStateEntities();
        private HttpResponseMessage _response;

        /// <summary>
        /// Get all Status
        /// </summary>
        /// <returns></returns>
        [System.Web.Http.HttpGet]
        public HttpResponseMessage GetStatus()
        {
            try
            {
                var result = _aRealStateEntities.Status.ToList();
                _response = Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception e)
            {
                _response = Request.CreateResponse(HttpStatusCode.NotFound, e);
            }
            return _response;
        }
        /// <summary>
        /// Get All Property Type
        /// </summary>
        /// <returns></returns>
        [System.Web.Http.HttpGet]
        public HttpResponseMessage GetPropertyType()
        {
            try
            {
                var result = _aRealStateEntities.PropertyTypes.ToList();
                _response = Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception e)
            {
                _response = Request.CreateResponse(HttpStatusCode.NotFound, e);
            }
            return _response;
        }
        /// <summary>
        /// Get All Property Sub Type
        /// </summary>
        /// <returns></returns>
        [System.Web.Http.HttpGet]
        public HttpResponseMessage GetPropertySubType()
        {
            try
            {
                var result = _aRealStateEntities.PropertySubTypes.ToList();
                _response = Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception e)
            {
                _response = Request.CreateResponse(HttpStatusCode.NotFound, e);
            }
            return _response;
        }
        /// <summary>
        /// Get All Sub Property Type by Property Type Id
        /// </summary>
        /// <param name="id">Property Type Id</param>
        /// <returns></returns>
        [System.Web.Http.HttpGet]
        public HttpResponseMessage GetPropertyByType(int? id)
        {
            try
            {
                var result = _aRealStateEntities.PropertySubTypes.Where(w => w.TypeId == id).ToList();
                _response = Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception e)
            {
                _response = Request.CreateResponse(HttpStatusCode.NotFound, e);
            }
            return _response;
        }
        /// <summary>
        /// Get All Area
        /// </summary>
        /// <returns></returns>
        public HttpResponseMessage GetArea()
        {
            try
            {
                var result = _aRealStateEntities.Areas.ToList();
                _response = Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception e)
            {
                _response = Request.CreateResponse(HttpStatusCode.NotFound, e);
            }
            return _response;
        }
    }
}
