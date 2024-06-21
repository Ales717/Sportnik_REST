using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Naloga2.Models;

namespace Naloga2.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TekmovanjaController : Controller
	{
		private readonly MyDbContext _context;

		public TekmovanjaController(MyDbContext context)
		{
			_context = context;
		}
		[HttpGet]
		public async Task<ActionResult<IEnumerable<Tekmovanje>>> GetTekmovanja()
		{
			return await _context.tekmovanje.ToListAsync();
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<Tekmovanje>> GetTekmovanje(int id)
		{
			var tekmovanje = await _context.tekmovanje.FindAsync(id);

			if (tekmovanje == null)
			{
				return NotFound();
			}

			return tekmovanje;
		}
        [HttpGet("ime/{ime}")]
        public async Task<ActionResult<List<Tekmovanje>>> GetTekmovanjaByName(string ime)
        {
            var tekmovanja = await _context.tekmovanje.Where(t => t.ime.Contains(ime)).ToListAsync();

            if (tekmovanja == null || tekmovanja.Count == 0)
            {
                return NotFound();
            }

            return tekmovanja;
        }

        [HttpPost]
		public async Task<ActionResult<Tekmovanje>> PostTekmovanje(Tekmovanje tekmovanje)
		{
			_context.tekmovanje.Add(tekmovanje);
			await _context.SaveChangesAsync();

			return CreatedAtAction(nameof(GetTekmovanja), tekmovanje);
		}


		[HttpPut("{id}")]
		public async Task<IActionResult> PutTekmovanje(int id, [FromBody] Tekmovanje tekmovanje)
		{
			if (id != tekmovanje.id)
			{
				return BadRequest();
			}

			tekmovanje.id = id;

			_context.Entry(tekmovanje).State = EntityState.Modified;
			await _context.SaveChangesAsync();

			return NoContent();
		}


		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteTekmovanje(int id)
		{
			var tekmovanje = await _context.tekmovanje.FindAsync(id);

			if (tekmovanje == null)
			{
				return NotFound();
			}

			_context.tekmovanje.Remove(tekmovanje);
			await _context.SaveChangesAsync();

			return NoContent();
		}
	}
}
