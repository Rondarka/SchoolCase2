using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiSchoolCase2.DB;

namespace WebApiSchoolCase2.Models
{
    public class TimeTableStorage
    {
        private Case2DBEntities db = new Case2DBEntities();
        public TimeTableStorage()
        {
            db.Configuration.ProxyCreationEnabled = false;
        }

        public TimeTableStorage(List<DB.TimeTable> timeTable)
        {
            Monday = timeTable.Where(p => p.DayOfTheWeek.ToLower() == "monday").ToList().ConvertAll(p => new TimeTableDayStorage(p));
            Tuesday = timeTable.Where(p => p.DayOfTheWeek.ToLower() == "tuesday").ToList().ConvertAll(p => new TimeTableDayStorage(p));
            Wednesday = timeTable.Where(p => p.DayOfTheWeek.ToLower() == "wednesday").ToList().ConvertAll(p => new TimeTableDayStorage(p));
            Thursday = timeTable.Where(p => p.DayOfTheWeek.ToLower() == "thursday").ToList().ConvertAll(p => new TimeTableDayStorage(p));
            Friday = timeTable.Where(p => p.DayOfTheWeek.ToLower() == "friday").ToList().ConvertAll(p => new TimeTableDayStorage(p));
            while (Monday.Count < 8)
            {
                for (int i = 1; i <= 8; i++)
                {
                    if (Monday.FirstOrDefault(p => p.Сount == i) == null)
                    {
                        Monday.Add(new TimeTableDayStorage(i));
                    }
                }
            }
            while (Tuesday.Count < 8)
            {
                for (int i = 1; i <= 8; i++)
                {
                    if (Tuesday.FirstOrDefault(p => p.Сount == i) == null)
                    {
                        Tuesday.Add(new TimeTableDayStorage(i));
                    }
                }
            }
            while (Wednesday.Count < 8)
            {
                for (int i = 1; i <= 8; i++)
                {
                    if (Wednesday.FirstOrDefault(p => p.Сount == i) == null)
                    {
                        Wednesday.Add(new TimeTableDayStorage(i));
                    }
                }
            }
            while (Thursday.Count < 8)
            {
                for (int i = 1; i <= 8; i++)
                {
                    if (Thursday.FirstOrDefault(p => p.Сount == i) == null)
                    {
                        Thursday.Add(new TimeTableDayStorage(i));
                    }
                }
            }
            while (Friday.Count < 8)
            {
                for (int i = 1; i <= 8; i++)
                {
                    if (Friday.FirstOrDefault(p => p.Сount == i) == null)
                    {
                        Friday.Add(new TimeTableDayStorage(i));
                    }
                }
            }
            Monday = Monday.OrderBy(p => p.Сount).ToList();
            Tuesday = Tuesday.OrderBy(p => p.Сount).ToList();
            Wednesday = Wednesday.OrderBy(p => p.Сount).ToList();
            Thursday = Thursday.OrderBy(p => p.Сount).ToList();
            Friday = Friday.OrderBy(p => p.Сount).ToList();

        }
        public List<TimeTableDayStorage> Monday { get; set; }
        public List<TimeTableDayStorage> Tuesday { get; set; }
        public List<TimeTableDayStorage> Wednesday { get; set; }
        public List<TimeTableDayStorage> Thursday { get; set; }
        public List<TimeTableDayStorage> Friday { get; set; }
    }
}