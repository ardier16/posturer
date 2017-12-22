using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace PosturerAPI.Models.Entities
{
    public class PosturerContext : IdentityDbContext<ApplicationUser>
    {
        public PosturerContext()
            : base("DbConnection")
        {
        }

        public static PosturerContext Create()
        {
            return new PosturerContext();
        }

        public DbSet<Chat> Chats { get; set; }
        public DbSet<UserChat> UserChats { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<ExerciseStep> ExerciseSteps { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<PostureLevel> PostureLevels { get; set; }
        public DbSet<ProgramExercise> ProgramExercises { get; set; }
        public DbSet<TrainingProgram> TrainingPrograms { get; set; }
    }
}
