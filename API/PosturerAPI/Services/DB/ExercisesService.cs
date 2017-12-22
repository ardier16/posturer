using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using PosturerAPI.Models.Entities;
using PosturerAPI.Models.View;

namespace PosturerAPI.Services.DB
{
    public class ExercisesService : DBService
    {
        public static IQueryable GetAllExercises()
        {
            return context.Exercises.Include("Steps").Select(e => new
            {
                e.ExerciseId,
                e.Description,
                e.DifficultyLevel,
                e.Steps
            });
        }

        public static ExerciseViewModel GetExerciseById(int id)
        {
            Exercise exercise = context.Exercises.Find(id);

            if (exercise == null)
            {
                throw new NullReferenceException();
            }

            List<ExerciseStepViewModel> steps = context.ExerciseSteps.Where(es =>
                es.ExerciseId == exercise.ExerciseId).Select(s => new ExerciseStepViewModel
                {
                    StepNumber = s.StepNumber,
                    Text = s.Text,
                    ImageUrl = s.ImageUrl
                }).ToList();

            return new ExerciseViewModel
            {
                ExerciseId = exercise.ExerciseId,
                Description = exercise.Description,
                DifficultyLevel = exercise.DifficultyLevel,
                Steps = steps
            };
        }

        public static void AddExercise(ExerciseViewModel model)
        {
            var ex = new Exercise
            {
                Description = model.Description,
                DifficultyLevel = model.DifficultyLevel,
            };

            context.Exercises.Add(ex);

            List<ExerciseStep> steps = new List<ExerciseStep>();

            for (int i = 0; i < model.Steps.Count; i++)
            {
                steps.Add(new ExerciseStep
                {
                    ExerciseId = ex.ExerciseId,
                    StepNumber = model.Steps[i].StepNumber,
                    Text = model.Steps[i].Text,
                    ImageUrl = model.Steps[i].ImageUrl
                });
            }

            context.ExerciseSteps.AddRange(steps);

            context.SaveChanges();
        }
    }
}