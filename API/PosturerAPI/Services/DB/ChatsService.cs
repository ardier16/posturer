using PosturerAPI.Models.Entities;
using PosturerAPI.Models.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PosturerAPI.Services.DB
{
    public class ChatsService : DBService
    {
        public static IQueryable<ChatViewModel> GetUserChats(string userId, string userName)
        {
            return context.UserChats.Where(m => m.UserId.Equals(userId)).Select(m =>
                new ChatViewModel
                {
                    ChatId = m.ChatId,
                    EMail = context.Users.FirstOrDefault(u => u.Id.Equals(context.UserChats.FirstOrDefault(c =>
                        !c.UserId.Equals(m.UserId) && c.ChatId.Equals(m.ChatId)).UserId)).Email,
                    UserName = context.Users.FirstOrDefault(u => u.Id.Equals(context.UserChats.FirstOrDefault(c =>
                        !c.UserId.Equals(m.UserId) && c.ChatId.Equals(m.ChatId)).UserId)).UserName
                });
        }

        public static IQueryable<MessageViewModel> GetUserMessages(string userId, string userName)
        {
            return context.Messages.Where(m => m.UserId.Equals(userId)).Select(m =>
                new MessageViewModel
                {
                    MessageId = m.MessageId,
                    SentDate = m.SentDate,
                    Text = m.Text,
                    UserName = userName
                });
        }

        public static List<MessageViewModel> GetUserChatMessages(string userId, int chatId)
        {
            Chat chat = context.Chats.FirstOrDefault(c => c.ChatId == chatId);

            if (chat == null)
            {
                throw new NullReferenceException();
            }

            UserChat uchat = context.UserChats.FirstOrDefault(u =>
                u.UserId.Equals(userId) && u.ChatId.Equals(chatId));

            if (!uchat.UserId.Equals(userId))
            {
                throw new UnauthorizedAccessException();
            }

            return context.Messages.Where(m => m.ChatId == chat.ChatId).Select(m =>
                new MessageViewModel
                {
                    MessageId = m.MessageId,
                    SentDate = m.SentDate,
                    Text = m.Text,
                    UserName = context.Users.FirstOrDefault(u => u.Id.Equals(m.UserId)).UserName
                }).ToList();
        }

        public static Message AddUserMessage(string userId, int chatId, MessageBindingModel model)
        {
            Chat chat = context.Chats.FirstOrDefault(c => c.ChatId == chatId);

            if (chat == null)
            {
                throw new NullReferenceException();
            }

            UserChat uchat = context.UserChats.FirstOrDefault(u =>
                u.UserId.Equals(userId) && u.ChatId.Equals(chatId));

            if (!uchat.UserId.Equals(userId))
            {
                throw new UnauthorizedAccessException();
            }

            var message = new Message
            {
                ChatId = chatId,
                SentDate = DateTime.Now,
                Text = model.Text,
                UserId = userId
            };

            context.Messages.Add(message);
            context.SaveChanges();

            return message;
        }
    }
}