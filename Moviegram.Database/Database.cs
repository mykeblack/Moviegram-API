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

        public MovieDBContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionbuilder)
        {
            optionbuilder.UseSqlite(@"Data Source=Moviegram.db");
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Showtime> Showtimes { get; set; }
        
    }
}
