using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using System.Web.Http.Cors;

using PosturerAPI.Models.Entities;
using PosturerAPI.Models.View;
using PosturerAPI.Services.DB;

namespace PosturerAPI.Controllers
{
    [Authorize]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class TrainingProgramController : ApiController
    {
        // GET api/TrainingProgram
        public IHttpActionResult Get()
        {
            string userId = User.Identity.GetUserId();
            TrainingProgramViewModel program;

            try
            {
                program = TrainingProgramsService.GetUserTrainingProgram(userId);
            }
            catch (NullReferenceException ex)
            {
                return BadRequest();
            }

            return Ok(program);
        }

        // POST api/TrainingProgram
        public IHttpActionResult Post()
        {
            string userId = User.Identity.GetUserId();
            TrainingProgramsService.AddUserTrainingProgram(userId);
            return Get();
        }
    }
}