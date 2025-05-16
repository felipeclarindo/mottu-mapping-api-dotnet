using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MotoMappingApiDotnet.Src.Database;
using MotoMappingApiDotnet.Src.Domain.Entities;

namespace MotoMappingApiDotnet.Src.WebApi.Controllers
{
    [ApiController]
    [Route("api/sectors")]
    public class SectorController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SectorController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sector>>> GetAll()
        {
            var sectors = await _context.Sectors
                .Include(s => s.PatioId)
                .ToListAsync();

            return Ok(sectors);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Sector>> GetById(long id)
        {
            var sector = await _context.Sectors
                .Include(s => s.PatioId)
                .FirstOrDefaultAsync(s => s.Id == id);

            if (sector == null)
                return NotFound();

            return Ok(sector);
        }

        [HttpPost]
        public async Task<ActionResult<Sector>> Create(Sector sector)
        {
            var patioExists = await _context.Patios
                .AnyAsync(p => p.Id == sector.PatioId);

            if (!patioExists)
                return BadRequest("PatioId inválido, o Patio relacionado não existe.");

            _context.Sectors.Add(sector);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = sector.Id }, sector);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, Sector sector)
        {
            if (id != sector.Id)
                return BadRequest();

            var patioExists = await _context.Patios
                .AnyAsync(p => p.Id == sector.PatioId);

            if (!patioExists)
                return BadRequest("PatioId inválido, o Patio relacionado não existe.");

            _context.Entry(sector).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SectorExists(id))
                    return NotFound();

                throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var sector = await _context.Sectors.FindAsync(id);

            if (sector == null)
                return NotFound();

            _context.Sectors.Remove(sector);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SectorExists(long id)
        {
            return _context.Sectors.Any(e => e.Id == id);
        }
    }
}
