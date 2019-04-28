using System;
using System.Collections.Generic;
using System.Text;

namespace Moviegram.Domain.Interfaces
{
    public class IMovieFactory
    {

        // creates an instance of the movie using a generic class
        public IMovie GetMovie() {
            var movie = new IMovie();
            return movie;
        }

        public IMovie GetMovie(int movieId) {
            var movie = new IMovie(movieId);
            return movie;
        }

        public List<IMovie> GetMovies() {
            var list = new List<IMovie>();
            return list;
        }
    }
}
