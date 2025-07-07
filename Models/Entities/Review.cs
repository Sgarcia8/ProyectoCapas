using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
    public class Review
    {
        public int ReviewId { get; set; }
        public string RevieText { get; set; }
        [ForeignKey("Film")]
        public int FilmId { get; set; }
        public Film Film { get; set; }


    }
}
