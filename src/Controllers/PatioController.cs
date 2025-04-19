using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Src.Models;

namespace Src.Controllers;

[ApiController]
[Route("api/patios/[controller]")]
public class PatioController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public PatioController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Patio>>> GetPatios()
    {
        return Ok(await _context.Patios.Include(p => p.Sectors).ToListAsync());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Patio>> GetPatio(long id)
    {
        var patio = await _context.Patios.Include(p => p.Sectors).FirstOrDefaultAsync(p => p.Id == id);
        if (patio == null) return NotFound();
        return Ok(patio);
    }

    [HttpPost]
    public async Task<ActionResult<Patio>> CreatePatio(Patio patio)
    {
        _context.Patios.Add(patio);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetPatio), new { id = patio.Id }, patio);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdatePatio(long id, Patio patio)
    {
        if (id != patio.Id) return BadRequest();

        _context.Entry(patio).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePatio(long id)
    {
        var patio = await _context.Patios.FindAsync(id);
        if (patio == null) return NotFound();

        _context.Patios.Remove(patio);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
