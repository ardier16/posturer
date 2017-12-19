using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using System.Web.Http.Cors;

using PosturerAPI.Models.Entities;
using PosturerAPI.Models.View;
using PosturerAPI.Services.DB;

namespace PosturerAPI.Controllers
{
    [Authorize]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/Chat")]
    public class ChatController : ApiController
    {
        // GET api/chat/chats
        [Route("Chats")]
        public IQueryable<ChatViewModel> GetChats()
        {
            string userId = User.Identity.GetUserId();
            string userName = User.Identity.Name;

            return ChatsService.GetUserChats(userId, userName);
        }
        
        // GET api/chat/messages
        [Route("Messages")]
        public IQueryable<MessageViewModel> GetMessages()
        {
            string userId = User.Identity.GetUserId();
            string userName = User.Identity.Name;

            return ChatsService.GetUserMessages(userId, userName);
        }

        // GET api/chat/5
        public IHttpActionResult GetChat(int id)
        {
            string userId = User.Identity.GetUserId();
            List<MessageViewModel> messages;

            try
            {
                messages = ChatsService.GetUserChatMessages(userId, id);
            }
            catch (NullReferenceException ex)
            {
                return BadRequest();
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized();
            }

            return Ok(messages);
        }

        // POST api/chat/5
        public IHttpActionResult Post(int id, [FromBody]MessageBindingModel model)
        {
            string userId = User.Identity.GetUserId();
            Message message;

            try
            {
                message = ChatsService.AddUserMessage(userId, id, model);
            }
            catch (NullReferenceException ex)
            {
                return BadRequest();
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized();
            }

            return Ok(message);
        }
    }
}