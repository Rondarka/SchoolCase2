using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiSchoolCase2.DB;

namespace WebApiSchoolCase2.Models
{
    public class ClassStorage
    {
        private Case2DBEntities db = new Case2DBEntities();
        public ClassStorage()
        {
            db.Configuration.ProxyCreationEnabled = false;
        }
        public ClassStorage(DB.Class _Class)
        {
            Id = _Class.Id;
            ClassName = _Class.Year + " " + _Class.Symbol;
        }
        public int Id { get; set; }
        public string ClassName { get; set; }
    }
}