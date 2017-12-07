using PosturerAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using System.Web.Http.Cors;

namespace PosturerAPI.Controllers
{
    [Authorize]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class PostureLevelController : ApiController
    {
        PosturerContext db = new PosturerContext();

        // GET api/PostureLevel
        public IEnumerable<PostureLevel> Get()
        {
            string UserId = User.Identity.GetUserId();
            return db.PostureLevels.Where(pl => pl.UserId.Equals(UserId));
        }

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
            db.PostureLevels.Add(new PostureLevel
            {
                Date = DateTime.Now,
                Level = model.Level,
                UserId = User.Identity.GetUserId(),
            });

            db.SaveChanges();

            return Ok();
        }
    }
}
