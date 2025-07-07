using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
    public class Film
    {
        public int FilmId { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public List<Review>? Reviews { get; set; }
        public List<Theater>? Theaters { get; set; }


    }
}
