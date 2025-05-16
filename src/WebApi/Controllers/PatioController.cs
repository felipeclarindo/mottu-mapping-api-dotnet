using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MotoMappingApiDotnet.Src.Database;
using MotoMappingApiDotnet.Src.Domain.Entities;

namespace MotoMappingApiDotnet.Src.WebApi.Controllers
{
    [ApiController]
    [Route("api/patios")]
    public class PatioController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PatioController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Patio>>> GetAll()
        {
            return Ok(await _context.Patios.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Patio>> GetById(long id)
        {
            var patio = await _context.Patios.FindAsync(id);
            if (patio == null) return NotFound();
            return Ok(patio);
        }

        [HttpPost]
        public async Task<ActionResult<Patio>> Create(Patio patio)
        {
            _context.Patios.Add(patio);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = patio.Id }, patio);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, Patio patio)
        {
            if (id != patio.Id) return BadRequest();
            _context.Entry(patio).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var patio = await _context.Patios.FindAsync(id);
            if (patio == null) return NotFound();
            _context.Patios.Remove(patio);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
