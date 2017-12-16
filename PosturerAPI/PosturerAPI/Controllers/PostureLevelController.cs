using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using System.Web.Http.Cors;

using PosturerAPI.Models.Entities;
using PosturerAPI.Models.View;


namespace PosturerAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class PostureLevelController : ApiController
    {
        PosturerContext db = new PosturerContext();

        [Authorize]
        // GET api/PostureLevel
        public IEnumerable<PostureLevel> Get()
        {
            string UserId = User.Identity.GetUserId();
            return db.PostureLevels.Where(pl => pl.UserId.Equals(UserId));
        }

        [Authorize]
        // GET api/PostureLevel/5
        public IHttpActionResult Get(int id)
        {
            PostureLevel pl = db.PostureLevels.Find(id);

            if (pl == null)
            {
                return BadRequest();
            }

            if (!pl.UserId.Equals(User.Identity.GetUserId()))
            {
                return Unauthorized();
            }

            return Ok(pl);
        }

        // POST api/PostureLevel
        public IHttpActionResult Post([FromBody]PostureLevelViewModel model)
        {
            if (db.Users.Find(model.UserId) == null)
            {
                return BadRequest();
            }

            db.PostureLevels.Add(new PostureLevel
            {
                Date = DateTime.Now,
                Level = model.Level,
                UserId = model.UserId,
            });

            db.SaveChanges();

            return Ok();
        }
    }
}
