using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models.DTOs.Film;
using Models.Entities;

namespace WebCinema.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FilmController: ControllerBase
    {
        // Inyecta el servicio genérico para la entidad Film con sus DTOs
        private readonly IGenericService<Film, FilmDTO> _filmService;

        public FilmController(IGenericService<Film, FilmDTO> filmService)
        {
            _filmService = filmService;
        }

        // GET: api/film
        [HttpGet]
        public async Task<IActionResult> GetFilms()
        {
            var films = await _filmService.GetAllAsync();
            return Ok(films);
        }
        // GET: api/film/{id}
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetFilm(int id)
        {
            var film = await _filmService.GetByIdAsync(id);
            if (film == null)
            {
                return NotFound($"Film with ID {id} not found.");
            }
            return Ok(film);
        }
        // POST: api/film
        [HttpPost]
        public async Task<IActionResult> CreateFilm([FromBody] FilmDTO filmDto)
        {
            if (filmDto == null)
            {
                return BadRequest("Film data is required.");
            }
            var createdFilm = await _filmService.AddAsync(filmDto);
            return CreatedAtAction(nameof(GetFilm), new { id = createdFilm.FilmId }, createdFilm);
        }
        // PUT: api/film/{id}
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateFilm(int id, [FromBody] FilmDTO filmDto)
        {
            if (filmDto == null)
            {
                return BadRequest("Film data is required.");
            }
            try
            {
                await _filmService.UpdateAsync(id, filmDto);
                return NoContent(); // 204 No Content
            }
            catch (KeyNotFoundException)
            {
                return NotFound($"Film with ID {id} not found.");
            }
        }
        // DELETE: api/film/{id}
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteFilm(int id)
        {
            try
            {
                await _filmService.DeleteAsync(id);
                return NoContent(); // 204 No Content
            }
            catch (KeyNotFoundException)
            {
                return NotFound($"Film with ID {id} not found.");
            }
        }

    }
}
