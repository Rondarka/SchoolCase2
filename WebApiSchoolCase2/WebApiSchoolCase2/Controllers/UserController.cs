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
using WebApiSchoolCase2.DB;

namespace WebApiSchoolCase2.Controllers
{
    public class UserController : ApiController
    {
        private Case2DBEntities db = new Case2DBEntities();

        public UserController()
        {
            db.Configuration.ProxyCreationEnabled = false;
        }

        // GET: api/User
        public IQueryable<Users> GetUsers()
        {
            return db.Users.Where(p => p.Position.ToLower() == "ученик");
        }

        // GET: api/User/5
        [ResponseType(typeof(List<Users>))]
        public IHttpActionResult GetUsers(int id)
        {
            Users user = db.Users.Find(id);
            List<Users> Peoples;
            if (user.Position == "Ученик")
            {
                Peoples = db.Users.Where(p => p.Position == "Учитель" && p.Id != user.Id).ToList();
                Peoples.AddRange(db.Users.Where(p => p.Group.FirstOrDefault().ClassId == db.Group.FirstOrDefault(c => c.StudentId == user.Id).ClassId && p.Id != user.Id));
            }
            else
            {
                Peoples = db.Users.Where(p => p.Id != user.Id).ToList();
            }

            Peoples = Peoples.Distinct<Users>().ToList();
            if (user == null)
            {
                return NotFound();
            }

            return Ok(Peoples);
        }

        [ResponseType(typeof(Users))]
        public IHttpActionResult GetUser(string login, string password)
        {
            Users user = db.Users.FirstOrDefault(p => p.Login == login && p.Password == password);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        // PUT: api/User/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUsers(int id, Users users)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != users.Id)
            {
                return BadRequest();
            }

            db.Entry(users).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsersExists(id))
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

        // POST: api/User
        [ResponseType(typeof(Users))]
        public IHttpActionResult PostUsers(Users users)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Users.Add(users);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = users.Id }, users);
        }

        // DELETE: api/User/5
        [ResponseType(typeof(Users))]
        public IHttpActionResult DeleteUsers(int id)
        {
            Users users = db.Users.Find(id);
            if (users == null)
            {
                return NotFound();
            }

            db.Users.Remove(users);
            db.SaveChanges();

            return Ok(users);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UsersExists(int id)
        {
            return db.Users.Count(e => e.Id == id) > 0;
        }
    }
}