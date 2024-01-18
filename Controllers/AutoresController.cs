using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebPagos.Contexts;
using WebPagos.Entities;

namespace WebPagos.Controllers;

[ApiController]
[Route("api/autores")]
public class AutoresController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    public AutoresController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<List<Autor>>> Get()
    {
        return await _context.Autores.Include( x => x.Libros ).ToListAsync();
    }

    [HttpPost]
    public async Task<ActionResult> Post(Autor autor)
    {
        _context.Add(autor);
        await _context.SaveChangesAsync();
        return Ok();
    }

    [HttpGet("first")]
    public async Task<ActionResult> ObtenerPrimerAutor()
    {
        return Ok(await _context.Autores.FirstOrDefaultAsync());
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult> Put(Autor autor, int id)
    {
        if (autor.Id != id)
        {
            return BadRequest("url erronea");
        }
        _context.Update(autor);
        await _context.SaveChangesAsync();
        return Ok();
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> Delete(int id)
    {
        var existe = await _context.Autores.AnyAsync(x => x.Id == id);
        if (!existe)
        {
            return NotFound();
        }
        _context.Remove(new Autor() { Id = id });
        await _context.SaveChangesAsync();
        return Ok();
    }

}
