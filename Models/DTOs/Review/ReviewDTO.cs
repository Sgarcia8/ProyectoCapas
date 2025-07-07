using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTOs.Review
{
    public class ReviewDTO
    {

        public int ReviewId { get; set; }
        public string RevieText { get; set; }
        public int FilmId { get; set; }
    }
}
