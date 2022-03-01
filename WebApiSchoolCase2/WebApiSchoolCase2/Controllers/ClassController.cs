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
    public class ClassController : ApiController
    {
        private Case2DBEntities db = new Case2DBEntities();

        public ClassController()
        {
            db.Configuration.ProxyCreationEnabled = false;
        }

        // GET: api/Class
        public List<Models.ClassStorage> GetClass()
        {
            return db.Class.ToList().ConvertAll(p => new Models.ClassStorage(p));
        }

        // GET: api/Class/5
        [ResponseType(typeof(Class))]
        public IHttpActionResult GetClass(int id)
        {
            Class @class = db.Class.Find(id);
            if (@class == null)
            {
                return NotFound();
            }

            return Ok(@class);
        }

        // PUT: api/Class/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutClass(int id, Class @class)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != @class.Id)
            {
                return BadRequest();
            }

            db.Entry(@class).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClassExists(id))
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

        // POST: api/Class
        [ResponseType(typeof(Class))]
        public IHttpActionResult PostClass(Class @class)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Class.Add(@class);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = @class.Id }, @class);
        }

        // DELETE: api/Class/5
        [ResponseType(typeof(Class))]
        public IHttpActionResult DeleteClass(int id)
        {
            Class @class = db.Class.Find(id);
            if (@class == null)
            {
                return NotFound();
            }

            db.Class.Remove(@class);
            db.SaveChanges();

            return Ok(@class);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ClassExists(int id)
        {
            return db.Class.Count(e => e.Id == id) > 0;
        }
    }
}