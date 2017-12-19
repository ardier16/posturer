using PosturerAPI.Models.Entities;

namespace PosturerAPI.Services.DB
{
    public abstract class DBService
    {
        protected static PosturerContext context = new PosturerContext();
    }
}