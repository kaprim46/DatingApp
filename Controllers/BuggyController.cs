using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class BuggyController : BaseApiController
    {
        private readonly DataContext _db;

        public BuggyController(DataContext db)
        {
            _db = db;
        }
        
        [Authorize]
        [HttpGet("auth")]
        public ActionResult<string> GetSecret()
        {
            return "secret text";
        }
        
        [HttpGet("not-found")]
        public ActionResult<AppUser> GetNotfound()
        {
            var thing = _db.Users.Find(-1);
            if(thing == null) return NotFound();
            return thing;
        }

        [HttpGet("server-error")]
        public ActionResult<string> GetServerError()
        {
            var thing = _db.Users.Find(-1);
            var thingToReturn = thing.ToString();
            return thingToReturn;
        }
        
        [HttpGet("bad-request")]
        public ActionResult<string> GetBadRequest()
        {
            return BadRequest("This was not a good request");
        }
    }
}