using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiSchoolCase2.DB;


namespace WebApiSchoolCase2.Models
{
    public class LessonStorage
    {
        private Case2DBEntities db = new Case2DBEntities();
        public LessonStorage()
        {
            db.Configuration.ProxyCreationEnabled = false;
        }
        public LessonStorage(DB.TimeTable timeTable)
        {
            CurrentLessonString = $"{DateTime.Now.ToString("M")}, {DateTime.Now.DayOfWeek}, {timeTable.Count} урок, {timeTable.Lessons.Name}";
            ClassId = timeTable.ClassId;
        }
        public string CurrentLessonString { get; set; }
        public int ClassId { get; set; }
    }
}