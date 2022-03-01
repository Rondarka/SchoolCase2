using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiSchoolCase2.DB;

namespace WebApiSchoolCase2.Models
{
    public class TimeTableDayStorage
    {
        private Case2DBEntities db = new Case2DBEntities();
        public TimeTableDayStorage()
        {
            db.Configuration.ProxyCreationEnabled = false;
        }

        public TimeTableDayStorage(int count)
        {
            Сount = count;
            Name = "Пусто";
        }
        public TimeTableDayStorage(DB.TimeTable timeTable)
        {
            Сount = timeTable.Count;
            Name = timeTable.Lessons.Name;
        }
        public int Сount { get; set; }
        public string Name { get; set; }
    }
}