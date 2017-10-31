using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Http;
using PosturerAPI.Models;

namespace PosturerAPI.Controllers
{
    public class ExercisesController : ApiController
    {
        private PosturerContext db = new PosturerContext();

        // GET: api/Exercises
        public IQueryable GetExercises()
        {
            return db.Exercises.Include("Steps").Select(e => new
            {
                e.ExerciseId,
                e.Description,
                e.DifficultyLevel,
                e.Steps
            });
        }

        // GET: api/Exercises/5
        public IHttpActionResult GetExercise(int id)
        {
            Exercise exercise = db.Exercises.Find(id);
            if (exercise == null)
            {
                return NotFound();
            }

            List<ExerciseStep> Steps = db.ExerciseSteps.Where(es => es.ExerciseId == exercise.ExerciseId).ToList();

            return Ok(new
            {
                exercise.ExerciseId,
                exercise.Description,
                exercise.DifficultyLevel,
                Steps
            });
        }

        // POST api/Exercises
        public IHttpActionResult Post([FromBody] ExerciseViewModel model)
        {
            var ex = new Exercise
            {
                Description = model.Description,
                DifficultyLevel = model.DifficultyLevel,
            };

            db.Exercises.Add(ex);

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

            db.ExerciseSteps.AddRange(steps);

            db.SaveChanges();

            return Ok();
        }
    }
}