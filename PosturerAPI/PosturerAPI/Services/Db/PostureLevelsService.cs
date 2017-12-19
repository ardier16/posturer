using System;
using System.Collections.Generic;
using System.Linq;

using PosturerAPI.Models.Entities;
using PosturerAPI.Models.View;

namespace PosturerAPI.Services.DB
{
    public class PostureLevelsService : DBService
    {
        public static IEnumerable<PostureLevel> GetUserPostureLevels(string userId)
        {
            return context.PostureLevels.Where(pl => pl.UserId.Equals(userId));
        }

        public static PostureLevel GetPostureLevelById(int id)
        {
            PostureLevel postureLevel = context.PostureLevels.Find(id);

            if (postureLevel == null)
            {
                throw new NullReferenceException();
            }

            return postureLevel;
        }

        public static void AddUserPostureLevel(PostureLevelViewModel model, string userId)
        {
            if (context.Users.Find(model.UserId) == null)
            {
                throw new NullReferenceException();
            }

            context.PostureLevels.Add(new PostureLevel
            {
                Date = DateTime.Now,
                Level = model.Level,
                UserId = model.UserId,
            });

            context.SaveChanges();
        }
    }
}