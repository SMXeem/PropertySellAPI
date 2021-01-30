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
    public class BookingController : ApiController
    {
        private readonly RealStateEntities _aRealStateEntities = new RealStateEntities();
        private HttpResponseMessage _response;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="aBooking"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage Post(Booking aBooking)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    _response = Request.CreateResponse(HttpStatusCode.NotAcceptable);
                }
                aBooking.Time=DateTime.Now;
                var a = _aRealStateEntities.Bookings.Add(aBooking);
                var b = _aRealStateEntities.SaveChanges();
                _response = Request.CreateResponse(HttpStatusCode.OK, a);
            }
            catch (Exception e)
            {
                _response = Request.CreateResponse(HttpStatusCode.BadRequest, e);
            }
            return _response;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public HttpResponseMessage DeleteBooking(int id)
        {
            try
            {
                Booking aBooking = _aRealStateEntities.Bookings.Find(id);
                if (aBooking!=null)
                {
                    _aRealStateEntities.Bookings.Remove(aBooking);
                }
                var b = _aRealStateEntities.SaveChanges();
                _response = Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception e)
            {
                _response = Request.CreateResponse(HttpStatusCode.BadRequest, e);
            }
            return _response;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public HttpResponseMessage Get()
        {
            try
            {
                var result = _aRealStateEntities.vBookings.ToList();
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
        public HttpResponseMessage Get(int id)
        {
            try
            {
                var result = _aRealStateEntities.vBookings.FirstOrDefault(w=>w.BId==id);
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
        /// <returns></returns>
        public HttpResponseMessage GetByBooker(int bOwnerId)
        {
            try
            {
                var result = _aRealStateEntities.vBookings.Where(w => w.BOwnerId == bOwnerId).ToList();
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
