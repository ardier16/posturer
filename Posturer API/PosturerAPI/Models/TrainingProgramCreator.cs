using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PosturerAPI.Models
{
    public class TrainingProgramCreator
    {
        /// <param name="UserId">Used to specify user</param>
        /// <param name="Db">Used to specify database context.</param>
        public static TrainingProgram Create(string UserId, PosturerContext Db)
        {
            TrainingProgram program = new TrainingProgram
            {
                UserId = UserId
            };

            Db.TrainingPrograms.Add(program);

            double avgPostureLevel = Db.PostureLevels.Where(pl =>
                pl.UserId.Equals(UserId)).Select(pl => pl.Level).Average();

            int postureLevel = (int)Math.Round(avgPostureLevel);

            List<Exercise> exercises = Db.Exercises.Where(e =>
                e.DifficultyLevel >= postureLevel - 1 &&
                e.DifficultyLevel <= postureLevel + 1).ToList();

            for (int i = 0; i < 7; i++)
            {
                Db.ProgramExercises.Add(new ProgramExercise
                {
                    ExerciseId = exercises[i].ExerciseId,
                    TrainingProgramId = program.TrainingProgramId
                });
            }

            Db.SaveChanges();
            return program;
        }
    }
}
