using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moviegram.Database;
using System.Linq;
using Moq;
using Microsoft.EntityFrameworkCore;

namespace Moviegram.Tests.Database
{
    [TestClass]
    public class MovieDbTests
    {
        [TestMethod]
        public void ConnectToDatabase()
        {
            using (var db = new MovieDBContext())
            {
                Assert.IsNotNull(db);
            }
        }

        // this uses the moq framework to create in-memory test doubles
        // one of the limitations of using entity is unit testing which can create different results in linq queries in certain circumstances
        [TestMethod]
        public void ReadMovie()
        {
            var mockSet = new Mock<DbSet<Movie>>();
            var mockContext = new Mock<MovieDBContext>();
            mockContext.Setup(m => m.Movies).Returns(mockSet.Object);

            var movie = new Moviegram.Database.Movie(mockContext.Object);
            movie.AddBlog("ADO.NET Blog", "http://blogs.msdn.com/adonet");

            mockSet.Verify(m => m.Add(It.IsAny<Blog>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }

        [TestMethod]
        public void MovieNotFound()
        {
            using (var db = new MovieDBContext())
            {
                var dbmovie = db.Movies.Where(x => x.Id == -1);
                Assert.IsNull(dbmovie);
            }
        }


    }
}
