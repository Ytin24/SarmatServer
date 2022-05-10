#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SarmatServer.Database;

namespace SarmatServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UsersContext _context;

        public UsersController(UsersContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Users>>> GetUser()
        {
            return await _context.Users.ToListAsync();
        }

        [HttpGet("{Login}")]
        public async Task<ActionResult<Users>> GetUser(string Login)
        {
            
            var user = _context.Users.Where(u=>u.Login == Login).AsEnumerable().First(t => t.Login == Login); ;

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }
        [HttpGet("{id},{Status}")]
        public async Task<ActionResult<Users>> SetOnline(int id,bool Status)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }
            if (user.Online != Status)
            {
                user.Online = Status;
                _context.SaveChanges();
                return user;
            }

            return user;
        }
        [HttpGet("GetOnlineUsers/{Online}")]
        public async Task<ActionResult<int>> GetOnline(bool Online)
        {
            var users = await _context.Users.ToListAsync();

            return users.Where(x => x.Online == Online).Count();
        }
        [HttpPost("AddNewUser")]
        public async Task<IActionResult> AddUser([FromBody]Users User)
        {
            if (User != null)
            {
                try
                {
                    _context.Users.Add(User);
                    _context.SaveChanges();
                    return Ok();
                }
                catch (Exception ex)
                {
                    return BadRequest();
                }
               
            }

            return BadRequest();
        }
    }
}
