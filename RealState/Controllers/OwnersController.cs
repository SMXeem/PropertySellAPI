using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using RealState.Manager;
using RealState.Models;

namespace RealState.Controllers
{
    /// <summary>
    /// Owner all operation
    /// </summary>
    public class OwnersController : ApiController
    {
        private readonly RealStateEntities _aRealStateEntities = new RealStateEntities();
        private HttpResponseMessage _response;
        /// <summary>
        /// Get all OwnerInfo
        /// </summary>
        /// <returns></returns>
        public HttpResponseMessage Get()
        {
            try
            {
                var result = _aRealStateEntities.Owners.ToList();
                _response = Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception e)
            {
                _response = Request.CreateResponse(HttpStatusCode.NotFound, e);
            }
            return _response;
        }
        /// <summary>
        /// Get Owner by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public HttpResponseMessage Get(int id)
        {
            try
            {
                var result = _aRealStateEntities.Owners.FirstOrDefault(w => w.Id==id);
                _response = Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception e)
            {
                _response = Request.CreateResponse(HttpStatusCode.NotFound, e);
            }
            return _response;
        }
        /// <summary>
        /// Get user by email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public HttpResponseMessage Get(string email)
        {
            try
            {
                var result = _aRealStateEntities.Owners.FirstOrDefault(w=>w.Email== email);
                _response = Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception e)
            {
                _response = Request.CreateResponse(HttpStatusCode.NotFound, e);
            }
            return _response;
        }
        //POST: api/Owners
        /// <summary>
        /// 
        /// </summary>
        /// <param name = "owner" ></ param >
        [ResponseType(typeof(Owner))]
        public HttpResponseMessage PostOwner(Owner owner)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    _response = Request.CreateResponse(HttpStatusCode.NotAcceptable);
                }

                if (!string.IsNullOrEmpty(owner.Password))
                    owner.Password = Common.Encrypt(owner.Password);
                var a=_aRealStateEntities.Owners.Add(owner);
                var b=_aRealStateEntities.SaveChanges();
                _response = Request.CreateResponse(HttpStatusCode.OK, a);
            }
            catch (Exception e)
            {
                _response = Request.CreateResponse(HttpStatusCode.BadRequest, e);
            }
            return _response;
        }





        // GET: api/Owners
        //public IQueryable<Owner> GetOwners()
        //{
        //    return _db.Owners;
        //}

        //// GET: api/Owners/5
        //[ResponseType(typeof(Owner))]
        //public IHttpActionResult GetOwner(int id)
        //{
        //    Owner owner = _db.Owners.Find(id);
        //    if (owner == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(owner);
        //}

        //// PUT: api/Owners/5
        ////[ResponseType(typeof(void))]
        ////public IHttpActionResult PutOwner(int id, Owner owner)
        ////{
        ////    if (!ModelState.IsValid)
        ////    {
        ////        return BadRequest(ModelState);
        ////    }

        ////    if (id != owner.Id)
        ////    {
        ////        return BadRequest();
        ////    }

        ////    _db.Entry(owner).State = EntityState.Modified;

        ////    try
        ////    {
        ////        _db.SaveChanges();
        ////    }
        ////    catch (DbUpdateConcurrencyException)
        ////    {
        ////        if (!OwnerExists(id))
        ////        {
        ////            return NotFound();
        ////        }
        ////        else
        ////        {
        ////            throw;
        ////        }
        ////    }

        ////    return StatusCode(HttpStatusCode.NoContent);
        ////}



        // DELETE: api/Owners/5
        //[ResponseType(typeof(Owner))]
        //public IHttpActionResult DeleteOwner(int id)
        //{
        //    Owner owner = _db.Owners.Find(id);
        //    if (owner == null)
        //    {
        //        return NotFound();
        //    }

        //    _db.Owners.Remove(owner);
        //    _db.SaveChanges();

        //    return Ok(owner);
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        _db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        //private bool OwnerExists(int id)
        //{
        //    return _db.Owners.Count(e => e.Id == id) > 0;
        //}
    }
}