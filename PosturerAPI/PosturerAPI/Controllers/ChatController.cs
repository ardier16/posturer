using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using PosturerAPI.Models;
using Microsoft.AspNet.Identity;
using System.Web.Http.Cors;

namespace PosturerAPI.Controllers
{
    [Authorize]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/Chat")]
    public class ChatController : ApiController
    {
        private PosturerContext db = new PosturerContext();

        [Route("Chats")]
        // GET api/chat/messages
        public IQueryable<ChatViewModel> GetChats()
        {
            string UserId = User.Identity.GetUserId();
            string userName = User.Identity.Name;

            return db.UserChats.Where(m => m.UserId.Equals(UserId)).Select(m =>
                new ChatViewModel
                {
                    ChatId = m.ChatId,
                    EMail = db.Users.FirstOrDefault(u => u.Id.Equals(db.UserChats.FirstOrDefault(c => !c.UserId.Equals(m.UserId) && c.ChatId.Equals(m.ChatId)).UserId)).Email,
                    UserName = db.Users.FirstOrDefault(u => u.Id.Equals(db.UserChats.FirstOrDefault(c => !c.UserId.Equals(m.UserId) && c.ChatId.Equals(m.ChatId)).UserId)).UserName
                });
        }



        [Route("Messages")]
        // GET api/chat/messages
        public IQueryable<MessageViewModel> GetMessages()
        {
            string UserId = User.Identity.GetUserId();
            string userName = User.Identity.Name;

            return db.Messages.Where(m => m.UserId.Equals(UserId)).Select(m =>
                new MessageViewModel
                {
                    MessageId = m.MessageId,
                    SentDate = m.SentDate,
                    Text = m.Text,
                    UserName = userName
                });
        }

        // GET api/chat/5
        public IHttpActionResult GetChat(int id)
        {
            string UserId = User.Identity.GetUserId();
            Chat chat = db.Chats.FirstOrDefault(c => c.ChatId == id);

            if (chat == null)
            {
                return BadRequest();
            }

            UserChat uchat = db.UserChats.FirstOrDefault(u => u.UserId.Equals(UserId) && u.ChatId.Equals(id));

            if (!uchat.UserId.Equals(UserId))
            {
                return Unauthorized();
            }

            List<MessageViewModel> messages = db.Messages.Where(m => m.ChatId == chat.ChatId).Select(m =>
                new MessageViewModel
                {
                    MessageId = m.MessageId,
                    SentDate = m.SentDate,
                    Text = m.Text,
                    UserName = db.Users.FirstOrDefault(u => u.Id.Equals(m.UserId)).UserName
                }).ToList();

            return Ok(messages);
        }

        // POST api/chat/5
        public IHttpActionResult Post(int id, [FromBody]MessageBindingModel model)
        {
            string UserId = User.Identity.GetUserId();
            Chat chat = db.Chats.FirstOrDefault(c => c.ChatId == id);
            
            if (chat == null)
            {
                return BadRequest();
            }

            UserChat uchat = db.UserChats.FirstOrDefault(u => u.UserId.Equals(UserId) && u.ChatId.Equals(id));

            if (!uchat.UserId.Equals(UserId))
            {
                return Unauthorized();
            }

            var message = new Message
            {
                ChatId = id,
                SentDate = DateTime.Now,
                Text = model.Text,
                UserId = User.Identity.GetUserId()
            };

            db.Messages.Add(message);

            db.SaveChanges();
            return Ok(message);
        }
    }
}