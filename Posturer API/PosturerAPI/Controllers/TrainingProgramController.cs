using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PosturerAPI.Models;
using Microsoft.AspNet.Identity;
using System.Web.Http.Cors;

namespace PosturerAPI.Controllers
{
    [Authorize]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class TrainingProgramController : ApiController
    {
        private PosturerContext db = new PosturerContext();

        // GET api/TrainingProgram
        public IHttpActionResult Get()
        {
            string UserId = User.Identity.GetUserId();
            TrainingProgram program = db.TrainingPrograms.FirstOrDefault(tp => tp.UserId.Equals(UserId));

            if (program == null)
            {
                return BadRequest();
            }

            List<int> prExsIds = db.ProgramExercises.Where(pe => 
                pe.TrainingProgramId == program.TrainingProgramId).Select(pe => pe.ExerciseId).ToList();
            List<Exercise> exercises = db.Exercises.Where(e => prExsIds.Contains(e.ExerciseId)).ToList();

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

            return Ok(new TrainingProgramModelView
            {
                UserId = UserId,
                TrainingProgramId = program.TrainingProgramId,
                Exercises = exModels
            });
        }

        // POST api/TrainingProgram
        public IHttpActionResult Post()
        {
            string UserId = User.Identity.GetUserId();

            if (db.TrainingPrograms.FirstOrDefault(tp => 
                tp.UserId.Equals(UserId)) != null)
            {
                return BadRequest("Программа уже создана");
            }

            if (TrainingProgramCreator.Create(User.Identity.GetUserId(), db) != null)
            {
                return Ok();
            }

            return NotFound();
        }
    }
}