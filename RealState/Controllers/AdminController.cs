using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using RealState.Manager;
using RealState.Models;

namespace RealState.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class AdminController : ApiController
    {
        private readonly RealStateEntities _aRealStateEntities = new RealStateEntities();
        private HttpResponseMessage _response;
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        public HttpResponseMessage UpdateStatus(int id, int statusId)
        {
            var request = HttpContext.Current.Request;

            try
            {
                var aProperty = _aRealStateEntities.Properties.Find(id);
                if (aProperty != null)
                {
                    aProperty.Status = statusId;
                    _aRealStateEntities.Properties.AddOrUpdate(aProperty);
                    // var saveProperty = _aRealStateEntities.Properties.Add(aProperty);
                    _aRealStateEntities.SaveChanges();
                    _response = Request.CreateResponse(HttpStatusCode.OK);
                }
            }
            catch (Exception e)
            {
                _response = Request.CreateResponse(HttpStatusCode.BadRequest, e);
            }
            return _response;
        }
    }
}
