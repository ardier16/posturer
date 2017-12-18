using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

using PosturerAPI.Models.Entities;
using PosturerAPI.Models.View;
using PosturerAPI.Services.Db;

namespace PosturerAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ExercisesController : ApiController
    {
        // GET: api/Exercises
        public IQueryable GetExercises()
        {
            return ExercisesService.GetAllExercises();
        }

        // GET: api/Exercises/5
        public IHttpActionResult GetExercise(int id)
        {
            ExerciseViewModel exercise;

            try
            {
                exercise = ExercisesService.GetExerciseById(id);
            }
            catch (NullReferenceException ex)
            {
                return NotFound();
            }

            return Ok(exercise);
        }

        // POST api/Exercises
        public IHttpActionResult Post([FromBody]ExerciseViewModel model)
        {
            ExercisesService.AddExercise(model);
            return Ok();
        }
    }
}