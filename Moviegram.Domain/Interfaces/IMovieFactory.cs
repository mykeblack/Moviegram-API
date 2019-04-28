using System;
using System.Collections.Generic;
using System.Text;

namespace Moviegram.Domain.Interfaces
{
    interface IMovieFactory
    {
        // creates an instance of the movie using a generic class
        Movie MovieFactory();

        Movie GetMovie(int movieId);

        List<Movie> GetMovies();
    }
}
