using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moviegram.Domain;
using System;

namespace Moviegram.Tests.Domain
{
    [TestClass]
    public class MovieDomainTests
    {
        [TestMethod]
        public void CreateMovie()
        {
            var mf = new MovieFactory();
            var movie = mf.CreateMovie();
            Assert.IsNotNull(movie);
        }

        [TestMethod]
        public void CountShowtimes()
        {
            var mf = new MovieFactory();
            var movie = mf.CreateMovie();
            int numShowtimes = movie.Showtimes.Count;
            Assert.AreEqual(numShowtimes, 0);
        }

        [TestMethod]
        public void GetSetMovieProperties()
        {
            var mf = new MovieFactory();
            var movie = mf.CreateMovie();
            movie.Title = "Test";
            Assert.AreEqual(movie.Title, "Test");
        }

        [TestMethod]
        public void GetSetShowtimeProperties()
        {
            var mf = new MovieFactory();
            var movie = mf.CreateMovie();
            var showtime = new Showtime {
                Id = 1,
                Time = DateTime.Now,
                Channel="TestChannel"
            };
            movie.Showtimes.Add(showtime);
            int numShowtimes = movie.Showtimes.Count;
            Assert.AreEqual(numShowtimes, 1);

            Assert.AreEqual(movie.Showtimes[0].Channel, "TestChannel");
        }

    }
}
