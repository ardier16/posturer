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
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/PostureLevel")]
    public class PostureLevelController : ApiController
    {
        [Authorize]
        // GET api/PostureLevel
        public IEnumerable<PostureLevel> Get()
        {
            string userId = User.Identity.GetUserId();
            return PostureLevelsService.GetUserPostureLevels(userId);
        }

        // GET api/PostureLevel/5
        public IHttpActionResult Get(int id)
        {
            try
            {
                PostureLevelsService.AddUserPostureLevel(new PostureLevelViewModel
                {
                    UserId = "74b43350-8275-42ae-91b3-152ae1944328",
                    Level = id
                }, "74b43350-8275-42ae-91b3-152ae1944328");
            }
            catch (NullReferenceException ex)
            {
                return BadRequest();
            }

            return Ok();
        }

        [Authorize]
        [Route("Current")]
        // GET api/PostureLevel/Current
        public PostureLevelViewModel GetCurrentLevel()
        {
            string userId = User.Identity.GetUserId();
            return PostureLevelsService.GetUserCurrentLevel(userId);
        }

        // POST api/PostureLevel
        public IHttpActionResult Post([FromBody]PostureLevelViewModel model)
        {
            try
            {
                PostureLevelsService.AddUserPostureLevel(model, User.Identity.GetUserId());
            }
            catch (NullReferenceException ex)
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}