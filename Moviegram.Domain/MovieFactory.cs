using Moviegram.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Moviegram.Domain
{
    public class MovieFactory : IMovieFactory
    {
        public Movie GetMovie()
        {
            var movie = new Movie();
            return movie;
        }

        public Movie GetMovie(int movieId)
        {
            var movie = new Movie(movieId);
            return movie;
        }

        public List<Movie> GetMovies()
        {
            var list = new List<Movie>();
            return list;
        }
    }
}
