using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiSchoolCase2.DB;

namespace WebApiSchoolCase2.Models
{
    public class GroupStorage
    {
        private Case2DBEntities db = new Case2DBEntities();
        public GroupStorage()
        {
            db.Configuration.ProxyCreationEnabled = false;
        }
        public GroupStorage(DB.Group group)
        {
            Id = group.StudentId;
            Name = group.Users.Name;
            Comment = "";
            Mark = "";
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Comment { get; set; }
        public string Mark { get; set; }
    }
}