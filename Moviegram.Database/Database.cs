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

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Showtime> Showtimes { get; set; }

    }
}
