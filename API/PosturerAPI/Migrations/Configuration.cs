using System.Data.Entity.Migrations;
using PosturerAPI.Models.Entities;

namespace PosturerAPI.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<PosturerContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }
    }
}
