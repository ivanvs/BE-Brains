using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using T10_P1_2_start.Models;
using T10_P1_2_start.Repositories;

namespace T10_P1_2_start.Controllers
{
    public class AddressesController : ApiController
    {
        private IUnitOfWork db;

        public AddressesController(IUnitOfWork unitOfWork)
        {
            db = unitOfWork;
        }

        // GET: api/Addresses
        public IQueryable<Address> GetAddresses()
        {
            return db.AddressesRepository.Get().AsQueryable();
        }

        // GET: api/Addresses/5
        [ResponseType(typeof(Address))]
        public IHttpActionResult GetAddress(int id)
        {
            Address address = db.AddressesRepository.GetByID(id);
            if (address == null)
            {
                return NotFound();
            }

            return Ok(address);
        }

        // PUT: api/Addresses/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAddress(int id, Address address)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != address.Id)
            {
                return BadRequest();
            }

            db.AddressesRepository.Update(address);

            try
            {
                db.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AddressExists(id))
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

        // POST: api/Addresses
        [ResponseType(typeof(Address))]
        public IHttpActionResult PostAddress(Address address)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.AddressesRepository.Insert(address);
            db.Save();

            return CreatedAtRoute("DefaultApi", new { id = address.Id }, address);
        }

        // DELETE: api/Addresses/5
        [ResponseType(typeof(Address))]
        public IHttpActionResult DeleteAddress(int id)
        {
            Address address = db.AddressesRepository.GetByID(id);
            if (address == null)
            {
                return NotFound();
            }

            db.AddressesRepository.Delete(address);
            db.Save();

            return Ok(address);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AddressExists(int id)
        {
            return db.AddressesRepository.GetByID(id) != null;
        }
    }
}
