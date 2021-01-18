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
using RealState.Models;

namespace RealState.Controllers
{
    /// <summary>
    /// Owner all operation
    /// </summary>
    public class OwnersController : ApiController
    {
        private readonly RealStateEntities _db = new RealStateEntities();

        // GET: api/Owners
        public IQueryable<Owner> GetOwners()
        {
            return _db.Owners;
        }

        // GET: api/Owners/5
        [ResponseType(typeof(Owner))]
        public IHttpActionResult GetOwner(int id)
        {
            Owner owner = _db.Owners.Find(id);
            if (owner == null)
            {
                return NotFound();
            }

            return Ok(owner);
        }

        // PUT: api/Owners/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutOwner(int id, Owner owner)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != owner.Id)
            {
                return BadRequest();
            }

            _db.Entry(owner).State = EntityState.Modified;

            try
            {
                _db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OwnerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Owners
        [ResponseType(typeof(Owner))]
        public IHttpActionResult PostOwner(Owner owner)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _db.Owners.Add(owner);
            _db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = owner.Id }, owner);
        }

        // DELETE: api/Owners/5
        [ResponseType(typeof(Owner))]
        public IHttpActionResult DeleteOwner(int id)
        {
            Owner owner = _db.Owners.Find(id);
            if (owner == null)
            {
                return NotFound();
            }

            _db.Owners.Remove(owner);
            _db.SaveChanges();

            return Ok(owner);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool OwnerExists(int id)
        {
            return _db.Owners.Count(e => e.Id == id) > 0;
        }
    }
}