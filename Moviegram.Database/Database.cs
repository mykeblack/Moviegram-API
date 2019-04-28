using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Moviegram.Database
{
    public class MovieDBContext : DbContext
    {

        public MovieDBContext(DbContextOptions<MovieDBContext> options) : base(options)
        { }

        // simple context contrutor without db options
        public MovieDBContext() : base()
        { }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Showtime> Showtimes { get; set; }
        
    }
}
