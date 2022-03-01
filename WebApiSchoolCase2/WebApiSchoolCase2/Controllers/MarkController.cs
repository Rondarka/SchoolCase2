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
    public class MarkController : ApiController
    {
        private Case2DBEntities db = new Case2DBEntities();

        public MarkController()
        {
            db.Configuration.ProxyCreationEnabled = false;
        }

        // GET: api/Mark
        public IQueryable<Marks> GetMarks()
        {
            return db.Marks;
        }

        // GET: api/Mark/5
        [ResponseType(typeof(List<Models.LessonsMarksStorage>))]
        public IHttpActionResult GetMarks(int StudentId)
        {
            List<Models.LessonsMarksStorage> lessons = db.Lessons.ToList().ConvertAll(p => new Models.LessonsMarksStorage(p, StudentId));
            if (lessons == null)
            {
                return NotFound();
            }

            return Ok(lessons);
        }

        // PUT: api/Mark/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMarks(int id, Marks marks)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != marks.Id)
            {
                return BadRequest();
            }

            db.Entry(marks).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MarksExists(id))
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

        // POST: api/Mark
        [ResponseType(typeof(Marks))]
        public IHttpActionResult PostMarks(Marks marks)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Marks.Add(marks);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = marks.Id }, marks);
        }

        // DELETE: api/Mark/5
        [ResponseType(typeof(Marks))]
        public IHttpActionResult DeleteMarks(int id)
        {
            Marks marks = db.Marks.Find(id);
            if (marks == null)
            {
                return NotFound();
            }

            db.Marks.Remove(marks);
            db.SaveChanges();

            return Ok(marks);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MarksExists(int id)
        {
            return db.Marks.Count(e => e.Id == id) > 0;
        }
    }
}