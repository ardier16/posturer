using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PosturerAPI.Models
{
    public class TrainingProgramCreator
    {
        public static TrainingProgram Create(string UserId, PosturerContext db)
        {
            TrainingProgram program = new TrainingProgram
            {
                UserId = UserId
            };

            db.TrainingPrograms.Add(program);

            double avgPostureLevel = db.PostureLevels.Where(pl => 
                pl.UserId.Equals(UserId)).Select(pl => pl.Level).Average();

            int postureLevel = (int) Math.Round(avgPostureLevel);
            List<Exercise> exercises = db.Exercises.Where(e =>
                e.DifficultyLevel >= postureLevel - 1 &&
                e.DifficultyLevel <= postureLevel + 1).ToList();

            for (int i = 0; i < 7; i++)
            {
                db.ProgramExercises.Add(new ProgramExercise
                {
                    ExerciseId = exercises[i].ExerciseId,
                    TrainingProgramId = program.TrainingProgramId
                });
            }

            db.SaveChanges();
            return program;
        }
    }
}
