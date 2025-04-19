using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Src.Models;

namespace Src.Controllers;

[ApiController]
[Route("api/sector/[controller]")]
public class SectorController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public SectorController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Sector>>> GetSectors()
    {
        return await _context.Sectors
            .Include(s => s.Motos)
            .Include(s => s.Patio)
            .ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Sector>> GetSector(int id)
    {
        var sector = await _context.Sectors
            .Include(s => s.Motos)
            .Include(s => s.Patio)
            .FirstOrDefaultAsync(s => s.Id == id);

        if (sector == null)
        {
            return NotFound();
        }

        return sector;
    }

    [HttpPost]
    public async Task<ActionResult<Sector>> PostSector(Sector sector)
    {
        _context.Sectors.Add(sector);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetSector), new { id = sector.Id }, sector);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutSector(int id, Sector sector)
    {
        if (id != sector.Id)
        {
            return BadRequest();
        }

        _context.Entry(sector).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Sectors.Any(e => e.Id == id))
            {
                return NotFound();
            }
            throw;
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteSetor(int id)
    {
        var setor = await _context.Sectors.FindAsync(id);
        if (setor == null)
        {
            return NotFound();
        }

        _context.Sectors.Remove(setor);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
