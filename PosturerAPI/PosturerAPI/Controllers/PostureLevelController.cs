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
    public class PostureLevelController : ApiController
    {
        [Authorize]
        // GET api/PostureLevel
        public IEnumerable<PostureLevel> Get()
        {
            string userId = User.Identity.GetUserId();
            return PostureLevelsService.GetUserPostureLevels(userId);
        }

        [Authorize]
        // GET api/PostureLevel/5
        public IHttpActionResult Get(int id)
        {
            PostureLevel postureLevel;

            try
            {
                postureLevel = PostureLevelsService.GetPostureLevelById(id);
            }
            catch (NullReferenceException ex)
            {
                return BadRequest();
            }

            if (!postureLevel.UserId.Equals(User.Identity.GetUserId()))
            {
                return Unauthorized();
            }

            return Ok(postureLevel);
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