using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Src.Models;
using Src.Database;

namespace Src.Controllers
{
    [ApiController]
    [Route("api/motos")]
    public class MotoController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public MotoController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Moto>>> GetAll()
        {
            return Ok(await _context.Motos.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Moto>> GetById(long id)
        {
            var moto = await _context.Motos.FindAsync(id);
            if (moto == null) return NotFound();
            return Ok(moto);
        }

        [HttpGet("/sectors/{sectorId}")]
        public async Task<ActionResult<IEnumerable<Moto>>> GetBySectorId(long sectorId)
        {
            var motos = await _context.Motos.Where(m => m.SectorId == sectorId).ToListAsync();
            if (motos == null || !motos.Any()) return NotFound();
            return Ok(motos);
        }

        [HttpPost]
        public async Task<ActionResult<Moto>> Create(Moto moto)
        {
            _context.Motos.Add(moto);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = moto.Id }, moto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, Moto moto)
        {
            if (id != moto.Id) return BadRequest();
            _context.Entry(moto).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var moto = await _context.Motos.FindAsync(id);
            if (moto == null) return NotFound();
            _context.Motos.Remove(moto);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
