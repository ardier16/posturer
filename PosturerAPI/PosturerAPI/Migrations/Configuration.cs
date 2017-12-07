namespace PosturerAPI.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using PosturerAPI.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<PosturerAPI.Models.PosturerContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(PosturerAPI.Models.PosturerContext context)
        {
            if (context.Exercises.Count() == 0)
            {
                var e1 = new Exercise
                {
                    Description = "Exercise1 summary and overview",
                    DifficultyLevel = 5
                };

                var e2 = new Exercise
                {
                    Description = "Exercise2 summary and overview",
                    DifficultyLevel = 3
                };

                context.Exercises.AddRange(new[] { e1, e2 });

                var es1 = new ExerciseStep
                {
                    Exercise = e1,
                    ExerciseId = e1.ExerciseId,
                    StepNumber = 1,
                    Text = "Some text 1"
                };

                var es2 = new ExerciseStep
                {
                    Exercise = e1,
                    ExerciseId = e1.ExerciseId,
                    StepNumber = 2,
                    Text = "Some text 2"
                };

                context.ExerciseSteps.AddRange(new[] { es1, es2 });

                
            }

            if (context.Messages.Count() == 0)
            {
                var ch1 = new Chat
                {
                };

                var m1 = new Message
                {
                    ChatId = ch1.ChatId,
                    SentDate = DateTime.Now,
                    Text = "Hello",
                    UserId = "1390f977-cd9e-4475-adee-40cbeb23804f"
                };

                context.Chats.Add(ch1);
                context.Messages.Add(m1);
            }
        }
    }
}
