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

        List<Movie> GetMovies(string title, int limit, string keyword, string startdate, string enddate);

        bool AddMovie(Movie movie);

        bool DeleteMovie(int movieId);

    }
}
