using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiSchoolCase2.DB;

namespace WebApiSchoolCase2.Models
{
    public class ChatStorage
    {
        private Case2DBEntities db = new Case2DBEntities();
        public ChatStorage()
        {
            db.Configuration.ProxyCreationEnabled = false;
        }
        public ChatStorage(DB.ChatHistory chat)
        {
            Text = chat.Text;
            Time = chat.Date.ToString("HH:mm");
        }
        public string Text { get; set; }
        public string Time { get; set; }
    }
}