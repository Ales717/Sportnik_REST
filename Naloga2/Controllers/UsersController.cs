using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Naloga2.Models;

namespace Naloga2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly MyDbContext _context;

        public UsersController(MyDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Users>>> GetUsers()
        {
            return await _context.users.Take(200).ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Users>> GetUser(int id)
        {
            var rezultat = await _context.users.FindAsync(id);

            if (rezultat == null)
            {
                return NotFound();
            }
            return rezultat;
        }
        [HttpPost]
        public async Task<ActionResult<Users>> PostUser(Users user)
        {
            _context.users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUsers), user);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, Users user)
        {
            if (id != user.id)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletUser(int id)
        {
            var rezultat = await _context.users.FindAsync(id);

            if (rezultat == null)
            {
                return NotFound();
            }

            _context.users.Remove(rezultat);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet("{username}/{password}")]
        public async Task<ActionResult<Users>> GetUser(string username, string password)
        {
            var user = await _context.users.FirstOrDefaultAsync(u => u.username == username && u.password == password);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }


    }
}
