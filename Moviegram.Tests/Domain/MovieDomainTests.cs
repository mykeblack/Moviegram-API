using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moviegram.Domain;

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
            Assert.IsTrue(true);
        }


    }
}
