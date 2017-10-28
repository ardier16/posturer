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

        protected override void Seed(PosturerContext context)
        {
            if (context.Patients.Count() == 0)
            {
                var p1 = new Patient
                {
                    Name = "name1",
                    EMail = "email1",
                    Password = "pass1",
                    RegistrationDate = DateTime.Now
                };
                var p2 = new Patient
                {
                    Name = "name2",
                    EMail = "email2",
                    Password = "pass2",
                    RegistrationDate = DateTime.Now
                };
                var p3 = new Patient
                {
                    Name = "name3",
                    EMail = "email3",
                    Password = "pass3",
                    RegistrationDate = DateTime.Now
                };

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

                context.Patients.AddRange(new[] { p1, p2, p3 });
                context.Exercises.AddRange(new[] { e1, e2 });

                var es1 = new ExerciseStep
                {
                    Exercise = e1,
                    ExerciseID = e1.ExerciseID,
                    StepNumber = 1,
                    Text = "Some text 1"
                };

                var es2 = new ExerciseStep
                {
                    Exercise = e1,
                    ExerciseID = e1.ExerciseID,
                    StepNumber = 2,
                    Text = "Some text 2"
                };

                context.ExerciseSteps.AddRange(new[] { es1, es2 });
            }
        }
    }
}
