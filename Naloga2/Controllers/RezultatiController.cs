using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Naloga2.Models;

namespace Naloga2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RezultatiController : ControllerBase
    {
        private readonly MyDbContext _context;

        public RezultatiController(MyDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Rezultati>>> GetRezultati()
        {
            return await _context.rezultati.Take(200).ToListAsync();
        }



        [HttpGet("{id}")]
        public async Task<ActionResult<Rezultati>> GetRezultat(int id)
        {
            var rezultat = await _context.rezultati.FindAsync(id);

            if (rezultat == null)
            {
                return NotFound();
            }
            return rezultat;
        }
        [HttpGet("rezultati/ime_tekmovalca/{ime_tekmovalca}")]
        public async Task<ActionResult<List<Rezultati>>> GetRezultatiByImeTekmovalca(string ime_tekmovalca)
        {
            var rezultati = await _context.rezultati.Where(r => r.ime_tekmovalca.Contains(ime_tekmovalca)).ToListAsync();

            if (rezultati == null || rezultati.Count == 0)
            {
                return NotFound();
            }

            return rezultati;
        }


        [HttpPost]
        public async Task<ActionResult<Rezultati>> PostRezultat(Rezultati rezultat)
        {
            _context.rezultati.Add(rezultat);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetRezultati), rezultat);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutRezultat(int id, Rezultati rezultat)
        {
            if (id != rezultat.id)
            {
                return BadRequest();
            }

            _context.Entry(rezultat).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRezultat(int id)
        {
            var rezultat = await _context.rezultati.FindAsync(id);

            if (rezultat == null)
            {
                return NotFound();
            }

            _context.rezultati.Remove(rezultat);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet("rezultati/user_id/{user_id}")]
        public async Task<ActionResult<List<Rezultati>>> GetRezultatiByUserId(string user_id)
        {
            var rezultati = await _context.rezultati.Where(r => r.user_id.Contains(user_id)).ToListAsync();

            if (rezultati == null || rezultati.Count == 0)
            {
                return NotFound();
            }

            return rezultati;
        }
    }
}
