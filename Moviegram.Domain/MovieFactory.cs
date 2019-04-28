using Microsoft.EntityFrameworkCore;
using Moviegram.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Moviegram.Domain
{
    public class MovieFactory : IMovieFactory, IDisposable
    {
        private DbContext _context { get; set; }

        public Movie CreateMovie()
        {
            var movie = new Movie();
            return movie;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Movie GetMovie(int movieId)
        {
            var movie = new Movie(movieId);
            return movie;
        }

        // get movies uses optional parameters. We could create a dedicated searchParams struct to contain the various search parameters, and 
        // it would be good to do this, but for this simple example, we're using 5 parameters with optional defaults
        // note, dates are passed in as a string which means error handling for date formats is done on the domain model. We want to keep the api layer
        // as simple and lightweight as possible and keep all the computational stuff in the domain methods.
        public List<Movie> GetMovies(string title = "", int limit = 100, string keyword = "", string startdate = "", string enddate="")
        {
            var movieList = new List<Movie>();

            DateTime start = DateTime.MinValue;
            DateTime end = DateTime.MaxValue;
            DateTime.TryParse(startdate, out start);
            DateTime.TryParse(enddate, out end);

            try
            {
                using (var db = new Database.MovieDBContext())
                {

                    // get filtered list of movies from the database
                    var dbList = db.Movies.Where(x => x.Title == title || title == "")
                                        .Where(x => x.Title.Contains(keyword) || keyword == "")
                                        .Where(x => x.Description.Contains(keyword) || keyword == "")
                                        .Where(x => x.Showtimes.Any(s => s.Time >= start) || start == DateTime.MinValue)
                                        .Where(x => x.Showtimes.Any(s => s.Time <= end) || end == DateTime.MaxValue)
                                        .Take(limit)
                                        .ToList();


                    if (dbList.Count > 0)
                    {
                        // map the list of database movies to a list of domain movies
                        foreach (var m in dbList)
                        {
                            var movie = new Movie
                            {
                                Id = m.Id,
                                Title = m.Title,
                                Description = m.Description,
                                Image = m.Image,
                                Thumbnail = m.Thumbnail
                            };
                            m.Showtimes.ForEach(x => movie.Showtimes.Add(new Showtime
                            {
                                Id = x.Id,
                                Time = x.Time,
                                Channel = x.Channel
                            }));
                            movieList.Add(movie);
                        }
                    }
                }
            }
            catch {
                // error connecting to database
            }
            // if no movies found, this will return empty array
            return movieList;

        }

        Movie IMovieFactory.MovieFactory()
        {
            throw new NotImplementedException();
        }

        // constructor with dependency injection of database context
        public MovieFactory(Moviegram.Database.MovieDBContext context)
        {
            _context = context;
        }

        // constructor without dependency injection
        public MovieFactory()
        {
            _context = new Database.MovieDBContext() ;

        }

    }
}
