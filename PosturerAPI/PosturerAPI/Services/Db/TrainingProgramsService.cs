using System;
using System.Collections.Generic;
using System.Linq;

using PosturerAPI.Models.View;
using PosturerAPI.Models.Entities;

namespace PosturerAPI.Services.DB
{
    public class TrainingProgramsService : DBService
    {
        public static TrainingProgramViewModel GetUserTrainingProgram(string userId)
        {
            TrainingProgram program = context.TrainingPrograms.FirstOrDefault(tp =>
                tp.UserId.Equals(userId));

            if (program == null)
            {
                throw new NullReferenceException();
            }

            List<int> prExsIds = context.ProgramExercises.Where(pe =>
                pe.TrainingProgramId == program.TrainingProgramId).Select(pe => pe.ExerciseId).ToList();
            List<Exercise> exercises = context.Exercises.Where(e => prExsIds.Contains(e.ExerciseId)).ToList();

            List<ExerciseViewModel> exModels = new List<ExerciseViewModel>();

            for (int i = 0; i < exercises.Count; i++)
            {
                int exId = exercises[i].ExerciseId;

                exModels.Add(new ExerciseViewModel
                {
                    ExerciseId = exercises[i].ExerciseId,
                    Description = exercises[i].Description,
                });
            }

            return new TrainingProgramViewModel
            {
                UserId = userId,
                TrainingProgramId = program.TrainingProgramId,
                Exercises = exModels
            };
        }

        public static void AddUserTrainingProgram(string userId)
        {
            TrainingProgram program = context.TrainingPrograms.FirstOrDefault(tp =>
               tp.UserId.Equals(userId));

            if (program != null)
            {
                context.TrainingPrograms.Remove(program);
            }

            TrainingProgramGenerator.Generate(userId, context);
        }
    }
}