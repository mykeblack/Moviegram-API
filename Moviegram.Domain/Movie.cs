using Moviegram.Domain.Interfaces;
using System;
using System.Collections.Generic;
using Moviegram.Database;
using System.Linq;

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
            // get the movie from the database
            var db = new MovieDBContext(null);
            var dbMovie = db.Movies.FirstOrDefault(x => x.Id == movieId);
            // map db properties to domain model
            if (dbMovie != null) {
               Id = dbMovie.Id;
                Title = dbMovie.Title;
                Description = dbMovie.Description;
                Image = dbMovie.Image;
                Thumbnail = dbMovie.Thumbnail;
            }
            
        }
    }
}
