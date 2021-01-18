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
    /// 
    /// </summary>
    public class PropertyController : ApiController
    {
        // GET: api/Property
        private readonly RealStateEntities _aRealStateEntities = new RealStateEntities();
        private HttpResponseMessage _response;
        /// <summary>
        /// Get all Property
        /// </summary>
        /// <returns></returns>
        public HttpResponseMessage Get()
        {
            try 
            {
                var result = _aRealStateEntities.Properties.ToList();
                _response = Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception e)
            {
                _response = Request.CreateResponse(HttpStatusCode.NotFound, e);
            }
            return _response;
        }
        /// <summary>
        /// Get Property by Area Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public HttpResponseMessage GetPropertyByArea(int? id)
        {
            try 
            {
                var result = _aRealStateEntities.Properties.Where(w => w.Address == id).ToList();
                _response = Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception e)
            {
                _response = Request.CreateResponse(HttpStatusCode.NotFound, e);
            }
            return _response;
        }
        /// <summary>
        /// Get Property by Sub PropertyType
        /// </summary>
        /// <param name="id">Sub PropertyType Id</param>
        /// <returns></returns>
        public HttpResponseMessage GetPropertyBySubPropertyType(int? id)
        {
            try 
            {
                var result = _aRealStateEntities.Properties.Where(w => w.SubPropertyType == id).ToList();
                _response = Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception e)
            {
                _response = Request.CreateResponse(HttpStatusCode.NotFound, e);
            }
            return _response;
        }
        /// <summary>
        /// Get Property by type and address id
        /// </summary>
        /// <param name="typeId">Sub property Id</param>
        /// <param name="areaId">Area id</param>
        /// <returns></returns>
        public HttpResponseMessage GetPropertyBySubPropertyTypeAddress(int? typeId,int? areaId)
        {
            try 
            {
                var result = _aRealStateEntities.Properties.Where(w => w.SubPropertyType == typeId && w.Address == areaId ).ToList();
                _response = Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception e)
            {
                _response = Request.CreateResponse(HttpStatusCode.NotFound, e);
            }
            return _response;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public HttpResponseMessage GetPropertyByMinArea(int? id)
        {
            try
            {
                var result = _aRealStateEntities.Properties.Where(w => w.Address == id).ToList().OrderBy(x => x.SalePrice);
                _response = Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception e)
            {
                _response = Request.CreateResponse(HttpStatusCode.NotFound, e);
            }
            return _response;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public HttpResponseMessage GetPropertyByMaxArea(int? id)
        {
            try
            {
                var result = _aRealStateEntities.Properties.Where(w => w.Address == id).ToList()
                    .OrderByDescending(x => x.SalePrice);
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
