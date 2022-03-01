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
    public class GroupController : ApiController
    {
        private Case2DBEntities db = new Case2DBEntities();

        public GroupController()
        {
            db.Configuration.ProxyCreationEnabled = false;
        }

        // GET: api/Group
        public IQueryable<Group> GetGroup()
        {
            return db.Group;
        }

        // GET: api/Group/5
        [ResponseType(typeof(List<Models.GroupStorage>))]
        public IHttpActionResult GetGroup(int id)
        {
            var group = db.Group.Where(p => p.ClassId == id).ToList().ConvertAll(p => new Models.GroupStorage(p));
            if (group == null)
            {
                return NotFound();
            }

            return Ok(group);
        }

        // PUT: api/Group/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutGroup(int id, Group group)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != group.Id)
            {
                return BadRequest();
            }

            db.Entry(group).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GroupExists(id))
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

        // POST: api/Group
        [ResponseType(typeof(Group))]
        public IHttpActionResult PostGroup(Group group)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Group.Add(group);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = group.Id }, group);
        }

        // DELETE: api/Group/5
        [ResponseType(typeof(Group))]
        public IHttpActionResult DeleteGroup(int id)
        {
            Group group = db.Group.Find(id);
            if (group == null)
            {
                return NotFound();
            }

            db.Group.Remove(group);
            db.SaveChanges();

            return Ok(group);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GroupExists(int id)
        {
            return db.Group.Count(e => e.Id == id) > 0;
        }
    }
}