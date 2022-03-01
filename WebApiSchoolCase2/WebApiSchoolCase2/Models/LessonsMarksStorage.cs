using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiSchoolCase2.DB;

namespace WebApiSchoolCase2.Models
{
    public class LessonsMarksStorage
    {
        private Case2DBEntities db = new Case2DBEntities();
        public LessonsMarksStorage()
        {
            db.Configuration.ProxyCreationEnabled = false;
        }
        public LessonsMarksStorage(DB.Lessons lessons, int StudentId)
        {

            Lesson = lessons.Name;
            Mark = lessons.Marks.Where(p => p.StudentId == StudentId).ToList().ConvertAll(p => new MarkStorage() { Mark = p.Mark, Id = p.Id });

            double sum = 0;
            double count = 0;
            Midle = 0;
            foreach (var item in Mark)
            {
                try
                {
                    sum += Convert.ToInt32(item.Mark);
                    count += 1;
                }
                catch
                {
                }
            }
            if (count > 0)
            {
                Midle = sum / count;
                Midle = Math.Round(Midle, 2);
            }
        }
        public string Lesson { get; set; }
        public List<MarkStorage> Mark { get; set; }
        public double Midle { get; set; }
    }
}