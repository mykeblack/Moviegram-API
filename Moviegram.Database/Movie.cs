using System;
using System.Collections.Generic;

namespace Moviegram.Database
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; } 
        public string Description { get; set; }
        public string Image { get; set; }
        public string Thumbnail { get; set; }
        public List<Showtime> Showtimes { get; set; }
    }
}
