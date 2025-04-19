using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Src.Models;

namespace Src.Controllers;

[ApiController]
[Route("api/moto/[controller]")]
public class MotoController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public MotoController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Moto>>> GetMotos()
    {
        return Ok(await _context.Motos.Include(m => m.Sector).ToListAsync());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Moto>> GetMoto(long id)
    {
        var moto = await _context.Motos.FindAsync(id);
        if (moto == null) return NotFound();
        return Ok(moto);
    }

    [HttpPost]
    public async Task<ActionResult<Moto>> CreateMoto(Moto moto)
    {
        _context.Motos.Add(moto);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetMoto), new { id = moto.Id }, moto);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateMoto(long id, Moto moto)
    {
        if (id != moto.Id) return BadRequest();

        _context.Entry(moto).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteMoto(long id)
    {
        var moto = await _context.Motos.FindAsync(id);
        if (moto == null) return NotFound();

        _context.Motos.Remove(moto);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
