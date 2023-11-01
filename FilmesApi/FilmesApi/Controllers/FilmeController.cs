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
        _mapper = mapper;
    }

    /// <summary>
    /// Adiciona um filme ao banco de dados
    /// </summary>
    /// <param name="filmeDto">Objeto com os campos necessários para criação de um filme</param>
    /// <returns>IActionResult</returns>
    /// <response code="201">Caso inserção seja feita com sucesso</response>

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult AdicionaFilme([FromBody] CreateFilmeDto filmeDto)
    { 
        Filme filme = _mapper.Map<Filme>(filmeDto);
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
    [HttpPut("{id}")]

    public IActionResult AtualizaFilme(int id, [FromBody]
      UpdateFilmeDto filmeDto)     
    {   
          var filme = _context.Filmes.FirstOrDefault(
              filme => filme.Id == id); if (filme == null) return NotFound();
            _mapper.Map(filmeDto, filme);
            _context.SaveChanges();
            return NoContent();
     }
    [HttpPatch("{id}")]
    public IActionResult AtualizaFilmeParcial(int id, JSONPatchDocument<UpdateFilmeDto> patch)
    {
        var filme = _context.Filmes.FirstOrDefault(
            filme => filme.Id == id);
        if (filme == null) return NotFound();
        _mapper.Map(filmeDto, filme);
        _context.SaveChanges();
        return NoContent();

        var filmeParaAtualizar = _mapper.Map<UpdateFilmeDto>(filme);

        patch.ApplyTo(filmeParaAtualizar, ModelState);

        if (!TryValidateModel(filmeParaAtualizar))
        {
            return ValidationProblem(ModelState);
        }
        _mapper.Map(filmeParaAtualizar, filme);
        _context.SaveChanges();
        return NoContent();

        [HttpDelete("{id}")]
        public IActionResult DeletaFilme(int id)
        {
            var filme = _context.Filmes.FirstOrDefault(
                filme => filme.Id == id);
            if (filme == null) return NotFound();
            _context.Remove(filme);
            _context.SaveChanges();
            return NoContent();
        }
    }
}



