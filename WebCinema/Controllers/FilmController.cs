using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models.DTOs.Film;
using Models.DTOs.Review;
using Models.DTOs.Theater;
using Models.Entities;

namespace WebCinema.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FilmController: ControllerBase
    {
        // Inyecta el servicio genérico para la entidad Film con sus DTOs
        private readonly IGenericService<Film> _filmService;

        public FilmController(IGenericService<Film> filmService)
        {
            _filmService = filmService;
        }

        private FilmDTO MapToFilmDto(Film film)
        {
            if (film == null) return null;

            return new FilmDTO
            {
                FilmId = film.FilmId,
                Title = film.Title,
                Description = film.Description,
                // Asegúrate de que las propiedades de navegación se hayan cargado si las necesitas aquí
                ReviewsIds = film.Reviews?.Select(r => new ReviewDTOForFilm
                {
                    ReviewId = r.ReviewId
                }).ToList(),
                TheatersIdsAndNames = film.Theaters?.Select(t => new TheaterDTOForFilm
                {
                    TheaterId = t.TheaterId,
                    Name = t.Name
                }).ToList()
            };
        }

        private Film MapToFilmEntity(FilmDTO creationDto)
        {
            return new Film
            {
                Title = creationDto.Title,
                Description = creationDto.Description,
                
            };

        }

        private void ApplyUpdateToFilmEntity(FilmDTO updateDto, Film existingEntity)
        {
            // Solo aplica las propiedades que no son null (para actualizaciones parciales/PATCH)
            if (updateDto.Title != null) existingEntity.Title = updateDto.Title;
            if (updateDto.Description != null) existingEntity.Description = updateDto.Description;

            // Manejo de relaciones Many-to-Many para la actualización:
            //if (updateDto.TheatersIdsAndNames != null) // Si la lista de IDs de teatros se proporciona en el DTO
            //{
            //    existingEntity.Theaters.Clear(); // Limpia las relaciones existentes
            //    // Carga los nuevos objetos Theater de la DB y los adjunta
            //    foreach (var theaterId in updateDto.TheatersIdsAndNames)
            //    {
            //        var theater = _theaterRepository.GetByIdAsync(theaterId).Result; // ¡Usar .Result es malo! Usar await en método asíncrono
            //        if (theater != null)
            //        {
            //            existingEntity.Theaters.Add(theater);
            //        }
            //    }
            //}
            // Si updateDto.TheaterIds es null, significa que no se desea modificar esa relación.
        }

        // GET: api/film
        [HttpGet]
        public async Task<IActionResult> GetFilms()
        {
            var films = await _filmService.GetAllAsync();
            var filmDtos = films.Select(f => MapToFilmDto(f)).ToList();
            return Ok(filmDtos);
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
            return Ok(MapToFilmDto(film));
        }
        // POST: api/film
        [HttpPost]
        public async Task<IActionResult> CreateFilm([FromBody] FilmDTO filmDto)
        {
            if (filmDto == null)
            {
                return BadRequest("Film data is required.");
            }
            //var createdFilm = await _filmService.AddAsync(filmDto);
            //return CreatedAtAction(nameof(GetFilm), new { id = createdFilm.FilmId }, createdFilm);



            var filmEntity = MapToFilmEntity(filmDto);

            // Manejo de Theaters: Adjuntar objetos Theater existentes a la nueva Film
            //if (filmDto.TheatersIdsAndNames != null && filmDto.TheatersIdsAndNames.Any())
            //{
            //    filmEntity.Theaters = new List<Theater>(); // Inicializa la colección
            //    foreach (var theaterId in filmDto.TheatersIdsAndNames)
            //    {
            //        var theater = await _theaterRepository.GetByIdAsync(theaterId);
            //        if (theater != null)
            //        {
            //            filmEntity.Theaters.Add(theater);
            //        }
            //    }
            //}

            var createdFilm = await _filmService.AddAsync(filmEntity);

        
            return CreatedAtAction(nameof(GetFilm), new { id = createdFilm.FilmId }, MapToFilmDto(createdFilm));
        }
        // PUT: api/film/{id}
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateFilm(int id, [FromBody] FilmDTO filmDto)
        {
            var existingFilm = await _filmService.GetByIdAsync(id);
            if (existingFilm == null)
            {
                return NotFound();
            }

            // Aplica los cambios del DTO a la entidad existente
            ApplyUpdateToFilmEntity(filmDto, existingFilm);

            try
            {
                // El servicio genérico actualizará la entidad existente que ya ha sido modificada
                await _filmService.UpdateAsync(id, existingFilm);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            return NoContent();
        }
        // DELETE: api/film/{id}
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteFilm(int id)
        {
            try
            {
                await _filmService.DeleteAsync(id);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            return NoContent();
        }

    }
}
