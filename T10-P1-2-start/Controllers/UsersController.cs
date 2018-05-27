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
    public class UsersController : ApiController
    {
        private IUnitOfWork db;

        public UsersController(IUnitOfWork unitOfWork)
        {
            db = unitOfWork;
        }

        // GET: api/Users
        public IQueryable<User> GetUsers()
        {
            return db.UsersRepository.Get().AsQueryable();
        }

        // GET: api/Users/5
        [ResponseType(typeof(User))]
        public IHttpActionResult GetUser(int id)
        {
            User user = db.UsersRepository.GetByID(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        // PUT: api/Users/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUser(int id, User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != user.Id)
            {
                return BadRequest();
            }

            db.UsersRepository.Update(user);

            try
            {
                db.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
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

        // POST: api/Users
        [ResponseType(typeof(User))]
        public IHttpActionResult PostUser(User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.UsersRepository.Insert(user);
            db.Save();

            return CreatedAtRoute("DefaultApi", new { id = user.Id }, user);
        }

        // DELETE: api/Users/5
        [ResponseType(typeof(User))]
        public IHttpActionResult DeleteUser(int id)
        {
            db.UsersRepository.Delete(id);
            db.Save();
            return Ok();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserExists(int id)
        {
            return db.UsersRepository.GetByID(id) != null;
        }

        [ResponseType(typeof(User))]
        [Route("api/users/{id}/address/{addressId}", Name = "AddAddress")]
        [HttpPut]
        public IHttpActionResult PutAddress(int id, int addressId = 0)
        {
            User user = db.UsersRepository.GetByID(id);

            if (user == null)
            {
                return NotFound();
            }

            Address address = db.AddressesRepository.GetByID(addressId);

            if (address == null)
            {
                return NotFound();
            }

            user.Address = address;
            db.UsersRepository.Update(user);
            db.Save(); // automatski ce biti sacuvana i adresa

            return CreatedAtRoute("AddAddress", new { id = user.Id, addressId = address.Id }, user);
        }
    }
}
