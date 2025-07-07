using Models.DTOs.Review;
using Models.DTOs.Theater;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTOs.Film
{
    public class FilmDTO
    {
        public int? FilmId { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public List<ReviewDTOForFilm>? ReviewsIds { get; set; }
        public List<TheaterDTOForFilm>? TheatersIdsAndNames { get; set; }
    }
}
