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
    public class ChatHistoriesController : ApiController
    {
        private Case2DBEntities db = new Case2DBEntities();
        public ChatHistoriesController()
        {
            db.Configuration.ProxyCreationEnabled = false;
        }

        // GET: api/ChatHistories
        public IQueryable<ChatHistory> GetChatHistory()
        {
            return db.ChatHistory;
        }

        // GET: api/ChatHistories/5
        [ResponseType(typeof(List<Models.ChatStorage>))]
        public IHttpActionResult GetChatHistory(int Senderid, int RecipientID)
        {
            var chatHistory = db.ChatHistory.Where(p => (p.SenderId == Senderid && p.RecipientId == RecipientID) || (p.RecipientId == Senderid && p.SenderId == RecipientID)).ToList().ConvertAll(p => new Models.ChatStorage(p));
            if (chatHistory == null)
            {
                return NotFound();
            }

            return Ok(chatHistory);
        }

        // PUT: api/ChatHistories/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutChatHistory(int id, ChatHistory chatHistory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != chatHistory.Id)
            {
                return BadRequest();
            }

            db.Entry(chatHistory).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChatHistoryExists(id))
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

        // POST: api/ChatHistories
        [ResponseType(typeof(ChatHistory))]
        public IHttpActionResult PostChatHistory(ChatHistory chatHistory, string text, int SenderId, int RecipientId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ChatHistory.Add(new ChatHistory() { Date = DateTime.Now, RecipientId = RecipientId, SenderId = SenderId, Text = text });
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = chatHistory.Id }, chatHistory);
        }

        // DELETE: api/ChatHistories/5
        [ResponseType(typeof(ChatHistory))]
        public IHttpActionResult DeleteChatHistory(int id)
        {
            ChatHistory chatHistory = db.ChatHistory.Find(id);
            if (chatHistory == null)
            {
                return NotFound();
            }

            db.ChatHistory.Remove(chatHistory);
            db.SaveChanges();

            return Ok(chatHistory);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ChatHistoryExists(int id)
        {
            return db.ChatHistory.Count(e => e.Id == id) > 0;
        }
    }
}