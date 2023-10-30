using FilmesApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Immutable;

namespace FilmesApi.Controllers;

[ApiController]
[Route("[controller]")]
 
public class FilmeController : ControllerBase
{
    private FilmeContext(FilmeContext context)
    {
        _context = context;
    }
    

    [HttpPost]
    public IActionResult AdicionaFilme([FromBody] CreateFilmeDto filmeDto)
    {
        _context.Filmes.Add(filme);
        _context.SaveChanges();
        return CreatedAtAction(nameof(RecuperaFilmePorId),
                new { id = filme.Id },
                filme);

    }

    [HttpGet]
    public IEnumerable<Filme> RecuperarFilmes([FromQuery] int skip = 0,
        [FromQuery] int take = 50) 
    {
        return _context.Filmes.Skip(skip).Take(take);
    
    }
    [HttpGet("{id}")]
    public IActionResult RecuperaFilmesPorId(int id)
    { 
        var filme =  _context.Filmes.FirstOrDefault(filmes => filmes.Id == id);
        if (filme == null) return NotFound();
        return Ok(filmes);
    }

        
}

