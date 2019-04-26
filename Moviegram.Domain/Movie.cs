using Moviegram.Domain.Interfaces;
using System;
using System.Collections.Generic;

namespace Moviegram.Domain
{
    public class Movie : IMovie<Movie>
    {
        public int Id { get; set; } = 0; // using autoinitialisers reduces chances of null references
        public string Title { get; set; } = "";
        public string Description { get; set; } = "";
        public string Image { get; set; } = "";
        public string Thumbnail { get; set; } = "";
        public List<Showtime> Showtimes { get; set; } = new List<Showtime>();

        // basic constructor
        public Movie() {

        }

        public Movie(int movieId) {

        }

        public static List<Movie> GetMovies() {
            var movieList = new List<Movie>();
            return movieList;
        }
    }
}
