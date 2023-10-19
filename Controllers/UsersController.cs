using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly DataContext _db;

        public UsersController(DataContext db)
        {
            _db = db;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
        {
             var users = await _db.Users.ToListAsync();
             return users;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<AppUser>> GetUser(int id)
        {
             var user = await _db.Users.FindAsync(id);
             return user;
        }
    }
}