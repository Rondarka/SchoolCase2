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
    public class LessonController : ApiController
    {
        private Case2DBEntities db = new Case2DBEntities();

        public LessonController()
        {
            db.Configuration.ProxyCreationEnabled = false;
        }

        // GET: api/Lesson
        public IQueryable<Lessons> GetLessons()
        {
            return db.Lessons;
        }

        // GET: api/Lesson/5
        [ResponseType(typeof(Models.LessonStorage))]
        public IHttpActionResult GetLessons(int id)
        {
            TimeTable lessons = new TimeTable();
            string NowDay = DateTime.Now.DayOfWeek.ToString();
            TimeSpan NowTime = DateTime.Now.TimeOfDay;
            lessons = db.TimeTable.FirstOrDefault(p => p.Lessons.TeacherId == id && p.DayOfTheWeek == NowDay && (p.Start <= NowTime && p.End >= NowTime));
            if (lessons == null)
            {
                return NotFound();
            }
            Models.LessonStorage lessonStorage = new Models.LessonStorage(lessons);
            return Ok(lessonStorage);
        }

        // PUT: api/Lesson/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLessons(int id, Lessons lessons)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != lessons.Id)
            {
                return BadRequest();
            }

            db.Entry(lessons).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LessonsExists(id))
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

        // POST: api/Lesson
        [ResponseType(typeof(Lessons))]
        public IHttpActionResult PostLessons(Lessons lessons)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Lessons.Add(lessons);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = lessons.Id }, lessons);
        }

        // DELETE: api/Lesson/5
        [ResponseType(typeof(Lessons))]
        public IHttpActionResult DeleteLessons(int id)
        {
            Lessons lessons = db.Lessons.Find(id);
            if (lessons == null)
            {
                return NotFound();
            }

            db.Lessons.Remove(lessons);
            db.SaveChanges();

            return Ok(lessons);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LessonsExists(int id)
        {
            return db.Lessons.Count(e => e.Id == id) > 0;
        }
    }
}