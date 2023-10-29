using FilmesApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Immutable;

namespace FilmesApi.Controllers;

[ApiController]
[Route("[controller]")]
public class FilmeController : ControllerBase
{

    private static List<Filme> filmes = new List<Filme>();
    private static int id = 0;

    [HttpPost]
    public void AdicionaFilme([FromBody] Filme filme)
    {
        filme.Id = id++;
        filmes.Add(filme);
        return CreatedAtAction(nameof(RecuperaFilmePorId),
                new { id = filme.Id },
                filme);

    }

    [HttpGet]
    public IEnumerable<Filme> RecuperarFilmes([FromQuery] int skip = 0,
        [FromQuery] int take = 50) 
    {
        return filmes.Skip(skip).Take(take);
    
    }
    [HttpGet("{id}")]
    public IActionResult RecuperaFilmesPorId(int id)
    {
        return filmes.FirstOrDefault(filmes => filmes.Id == id);
        if (filme == null) return NotFound();
        return Ok(filmes);
    }

        
}

